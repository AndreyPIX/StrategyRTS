
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using StrategyRTS.Menagers;
using System.Collections.Generic;

namespace StrategyRTS
{
    public class GameEngine : BaseManager<GameObject>
	{
		private List<BaseController> controllers;
		private List<BaseCollider> colliders;
		public GameEngine() : base()
		{
			controllers = new List<BaseController>();
			colliders = new List<BaseCollider>();
		}
		public override void Add(GameObject obj)
		{
			base.Add(obj);
			if (obj.HasCollider)
				colliders.Add(obj.Collider);
		}
		public void Add(BaseController controller)
		{
			controllers.Add(controller);
		}
		private void CheckCollisions()
		{
			bool hasCollision;
			GameObject objI;
			GameObject objY;
			for (int i = 0;  i < colliders.Count; i++)
			{
				objI = colliders[i].Master;
				for (int j = 0; j <  colliders.Count; j++)
				{
					if (i == j) continue;
					objY = colliders[j].Master;
					hasCollision = colliders[i].IsCollision(colliders[j]);
					if (hasCollision)
					{
						objI.UndoMove();
						objY.UndoMove();
					}
				}
			}
		}
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
            foreach (var item in controllers)
				item.Update(gameTime);
        }
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			foreach (var collider in colliders)
			{
				collider.Draw(spriteBatch);
			}
		}
	}
}
