
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.UserInterface
{
	public class UIButton : UIControlBase
	{

		private bool isButtonPressed;
		public bool IsPressed
		{
			get { return isButtonPressed; }
		}
		private bool isModeСlick;
		public bool IsModeСlick
		{
			set { isModeСlick = value; }
		}
		public UIButton(Texture2D textrureButtonReleased, SpriteFont font,  string text)
		{
			texture = textrureButtonReleased;
			isModeСlick = true;
			this.font = font;
		}
		public void StateButton()
		{
			MouseState state = Mouse.GetState();
			bool IsGuidedX = state.X > position.X && state.X < position.X + scale.X;
			bool IsGuidedY = state.Y > position.Y && state.Y < position.Y + scale.Y;
			isButtonPressed = IsGuidedX && IsGuidedY;
			bool isClick, isPressed;
			if (isModeСlick)
			{
				previousState = currentState;
				currentState = Mouse.GetState();
				isClick = previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed;
				isButtonPressed = isButtonPressed && isClick;
			}
			else
			{
				isPressed = currentState.LeftButton == ButtonState.Pressed;
				isButtonPressed = isButtonPressed && isPressed;
			}
		}
		public void SetTextPosition()
		{
			textPosition.X = texture.Width / 2;
			textPosition.Y = texture.Height / 2;
			textPosition -= font.MeasureString(text) / 2;
		}
		public override void Update(GameTime gameTime)
		{
			StateButton();
			if (text != null)
				SetTextPosition();
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			if (text != null)
				DrawString(spriteBatch);
		}
	}
}
