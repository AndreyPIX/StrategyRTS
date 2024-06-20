
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
		private bool hasShowCollider;
		public bool HasShowCollider
		{
			get { return hasShowCollider; }
			set { hasShowCollider = value; }
		}

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
			for (int i = 0;  i < colliders.Count; i++)
			{
				GameObject objI = colliders[i].Master;
				for (int j = 0; j <  colliders.Count; j++)
				{
					if (i == j) continue;
					GameObject objY = colliders[j].Master;
					if (objI.CollisionIndex != objY.CollisionIndex) continue;
					bool hasCollision = colliders[i].IsCollision(colliders[j]);
					if (hasCollision)
					{
						colliders[i].LineColor = Color.Red;
						objI.UndoMove();
					}
					else
					{
						colliders[i].LineColor = Color.White;
					}
				}
			}
		}
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
			KeyboardState state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.P))
			{
				int a = 1;
				int b = 1;
				b = a + b;
			}
			foreach (var item in controllers)
				item.Update(gameTime);
			
			CheckCollisions();
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			if (hasShowCollider)
			foreach (var collider in colliders)
			{
				collider.Draw(spriteBatch);
			}
		}
	}
}
