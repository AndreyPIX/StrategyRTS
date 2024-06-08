
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Colliders
{
	public abstract class BaseCollider
	{
		private Color lineColor;
		public Color LineColor
		{
			get { return lineColor; }
			set { lineColor = value; }
		}
		protected GameObject master;
		public GameObject Master
		{
			get { return master; }
		}
		public abstract void Draw(SpriteBatch spriteBatch);
		public virtual void SetMaster(GameObject master)
		{
			this.master = master;
		}
		public abstract bool IsCollision(BaseCollider collider, bool inversion = false);
		public abstract Rectangle GetBounds();
	}
}
