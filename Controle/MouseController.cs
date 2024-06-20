
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public abstract class MouseController : BaseController
	{
		private Vector2 cursorPosition;
		public Vector2 CursorPosition
		{
			get { return cursorPosition; }
		}
		public override void Update(GameTime gameTime)
		{
			MouseState state = Mouse.GetState();
			cursorPosition.X = state.X;
			cursorPosition.Y = state.Y;
		}
	}
}
