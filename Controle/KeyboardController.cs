
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public class KeyboardController : BaseController
	{
		protected KeyboardLayout layout;
		public KeyboardController()
		{
			layout = new KeyboardLayout();
		}
		public KeyboardController(KeyboardLayout layout)
		{
			this.layout = layout;
		}
		protected virtual Vector2 ProcessKeyAction(Keys key)
		{
			Vector2 delta = new Vector2(0);
			switch (layout.GetActionForKey(key))
			{
				case EnumKeyAction.None:
					break;
				case EnumKeyAction.MoveRight:
					delta.X = movingSpeed;
					break;
				case EnumKeyAction.MoveUp:
					delta.Y = -movingSpeed;
					break;
				case EnumKeyAction.MoveLeft:
					delta.X = -movingSpeed;
					break;
				case EnumKeyAction.MoveDown:
					delta.Y = movingSpeed;
					break;
			}
			delta.X = -movingSpeed;
			return delta;
		}
		public override void Update(GameTime gameTime)
		{
			Vector2 delta = new Vector2(0);
			KeyboardState state = Keyboard.GetState();
			Keys[] keys = state.GetPressedKeys();
			foreach (Keys key in keys)
				delta += ProcessKeyAction(key);
			puppet.Move(delta);
			//puppet.Move(new Vector2(-movingSpeed, 0));
		}
	}
}
