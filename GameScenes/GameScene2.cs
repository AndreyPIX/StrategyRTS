
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;
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
            GameObject GreenSquare = new GameObject(TextureGenerator.CreateFillTexture(500, 500, Color.Green));
            GreenSquare.SetPosition(new Vector2(100, 100));
            GreenSquare.AddCollider<RentangleCollider>();
            engine.Add(GreenSquare);
            GameObject BlueSquare = new GameObject(TextureGenerator.CreateFillTexture(500, 500, Color.Blue));
            BlueSquare.SetPosition(new Vector2(900, 100));
            BlueSquare.AddCollider<RentangleCollider>();
            KeyboardController controller = new KeyboardController(new KeyboardLayoutCameraControle());
            controller.Attach(BlueSquare);
            engine.Add(controller);
            engine.Add(BlueSquare);
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
