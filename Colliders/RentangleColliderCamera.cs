
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Colliders
{
    public class RentangleColliderCamera : RentangleCollider
    {
        private Camera camera;

		public override void SetMaster(GameObject master)
		{
			camera = (Camera)master;
			this.master = master;
			rectangle = new Rectangle(0, 0, camera.Width, camera.Height);
		}

		public override Rectangle GetBounds()
		{
			Rectangle rectangle = new Rectangle();
            rectangle.Width = (int)(this.rectangle.Width * master.Scale.X);
            rectangle.Height = (int)(this.rectangle.Height * master.Scale.Y);
            rectangle.X = (int)(master.Position.X);
            rectangle.Y = (int)(master.Position.Y);
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
