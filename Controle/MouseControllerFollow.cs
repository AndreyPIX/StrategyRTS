
using Microsoft.Xna.Framework;

namespace StrategyRTS.Controle
{
	public class MouseControllerFollow : MouseController
	{
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			puppet.SetTempPosition(CursorPosition);
		}
	}
}
