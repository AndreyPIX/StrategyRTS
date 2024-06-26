
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;
using StrategyRTS.Colliders;
using StrategyRTS.UserInterface;

namespace StrategyRTS.GameScenes
{
    public class GameSceneForTests : GameSceneBase
    {
		SpriteFont font;
        Texture2D sideOfTextrue;
        UIButton button;

		public GameSceneForTests(GameEngine engine, GraphicsDeviceManager graphics) : base(engine, graphics)
        {
            
        }
        public override void Initialize()
        {
            button = new UIButton(TextureGenerator.GenerateTexture(200, sideOfTextrue), font, "старт");
            button.SetPosition(new Vector2(250, 250));
            engine.Add(button);
		}
        public override void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("png/UserInterface/MainFont");
            sideOfTextrue = content.Load<Texture2D>("png/UserInterface/SideOfTexture");
		}
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Hello world", new Vector2(50, 50), Color.White);
        }
    }
}
