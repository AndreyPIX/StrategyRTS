
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Experemental;
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
			return base.GetBounds();
		}

		public override bool IsCollision(BaseCollider collider, bool inversion = false)
		{
			return base.IsCollision(collider, inversion);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
