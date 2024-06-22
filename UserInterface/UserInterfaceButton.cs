
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.UserInterface
{
	public class UserInterfaceButton : UserInterfaceControlBase
	{
		/*public bool StateButton()
		{
			/*MouseState state = Mouse.GetState();
			previousState = currentState;
			currentState = Mouse.GetState();
			return previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed &&
				state.X > position.X && state.X < position.X + scale.X &&
				state.Y > position.Y && state.Y < position.Y + scale.Y;
		}*/
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
