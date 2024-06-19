
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Experemental;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Colliders
{
	public class RentangleColliderMap : RentangleCollider
	{
		private Map map;

		public override void SetMaster(GameObject master)
		{
			map = (Map)master;
			this.master = master;
			rectangle = new Rectangle(0, 0, map.Width, map.Height);
		}

		public override Rectangle GetBounds()
		{
            Rectangle rectangle = new Rectangle();
            rectangle.Width = this.rectangle.Width;
			rectangle.Height = this.rectangle.Height;
			rectangle.X = (int)map.Position.X /*- rectangle.Width / 2*/;
			rectangle.Y = (int)map.Position.Y /*- rectangle.Height / 2*/;
            return rectangle;
        }

		private bool Intersects(Rectangle rect1, Rectangle rect2)
		{
			return rect1.Left < rect2.Left || rect1.Right > rect2.Right || rect1.Top < rect2.Top || rect1.Bottom > rect2.Bottom;
		}

		public override bool IsCollision(BaseCollider collider)
		{
			Rectangle rect1 = this.GetBounds();
			Rectangle rect2 = collider.GetBounds();
			return Intersects(rect1, rect2);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
