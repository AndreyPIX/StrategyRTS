
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;
using StrategyRTS.Experemental;

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
            camera.AddCollider<RentangleColliderCamera>();
			engine.Add(camera);

			KeyboardCameraController cameraController = new KeyboardCameraController(new KeyboardLayoutCameraControle());
			cameraController.Attach(camera);
            engine.Add(cameraController);
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
