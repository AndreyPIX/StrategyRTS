﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameMaths;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Colliders
{
	public class RentangleCollider : BaseCollider
	{
		protected Rectangle rectangle;
		public override void SetMaster(GameObject master)
		{
			base.SetMaster(master);
			Texture2D tex = master.Texture;
			rectangle = new Rectangle(0, 0, tex.Width, tex.Height);
        }
		public override Rectangle GetBounds()
		{
            Rectangle rectangle = new Rectangle();
            rectangle.Width = (int)(this.rectangle.Width * master.Scale.X);
            rectangle.Height = (int)(this.rectangle.Height * master.Scale.Y);
            rectangle.X = (int)(master.Position.X - rectangle.Width / 2);
            rectangle.Y = (int)(master.Position.Y - rectangle.Height / 2);
            return rectangle;
        }
		public override bool IsCollision(BaseCollider collider)
		{
            Rectangle rect1 = this.GetBounds();
            Rectangle rect2 = collider.GetBounds();
            return rect1.Intersects(rect2);
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			Rectangle rectangle = this.GetBounds();

			GameMath.DrawRectangle(spriteBatch, rectangle, master.Position, LineColor);
		}
	}
}
