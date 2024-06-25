using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Experemental;
using StrategyRTS.Menagers;

namespace StrategyRTS.UserInterface
{
	public class UISystem : BaseManager<UIControlBase>
	{
		public override void Add(UIControlBase obj)
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
