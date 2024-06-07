
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;

namespace StrategyRTS.GameScenes
{
    public class GameScene2 : GameSceneBase
    {
        public GameScene2(GameEngine engine, GraphicsDeviceManager graphics) : base(engine, graphics)
        {
            
        }
        public override void Initialize()
        {
			GameObject map = new GameObject();
            map.AddCollider<RentangleCollider>();
			engine.Add(map);

			GameObject camera = new GameObject();
            camera.AddCollider<RentangleCollider>();
            engine.Add(camera);
		}
        public override void LoadContent(ContentManager content)
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
