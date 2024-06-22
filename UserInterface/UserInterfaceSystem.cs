using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Experemental;
using StrategyRTS.Menagers;

namespace StrategyRTS.UserInterface
{
	public class UserInterfaceSystem : BaseManager<UserInterfaceControlBase>
	{
		public override void Add(UserInterfaceControlBase obj)
		{
			base.Add(obj);
		}
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
