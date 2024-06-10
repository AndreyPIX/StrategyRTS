
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;
using SharpDX.MediaFoundation;

namespace StrategyRTS.GameScenes
{
    public class GameScene2 : GameSceneBase
    {
        public GameScene2(GameEngine engine, GraphicsDeviceManager graphics) : base(engine, graphics)
        {
            
        }
        public override void Initialize()
        {
			Camera camera = new Camera(graphics);
            camera.NullTexture();
            camera.SetPosition(new Vector2(300, 300));
            camera.AddCollider<RentangleColliderCamera>();
			engine.Add(camera);

			Camera camera2 = new Camera(graphics);
			camera2.NullTexture();
            camera2.SetPosition(new Vector2(350, 350));
			camera2.AddCollider<RentangleColliderCamera>();
			engine.Add(camera2);
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
