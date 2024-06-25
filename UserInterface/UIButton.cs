
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace StrategyRTS.UserInterface
{
	public class UIButton : UIControlBase
	{
		public bool StateButton()
		{
			MouseState state = Mouse.GetState();
			previousState = currentState;
			currentState = Mouse.GetState();
			bool IsClick = previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed;
			bool IsGuidedX = state.X > position.X && state.X < position.X + scale.X;
			bool IsGuidedY = state.Y > position.Y && state.Y < position.Y + scale.Y;
			return IsClick && IsGuidedX && IsGuidedY;
		}
		public override void Update(GameTime gameTime)
		{

		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
