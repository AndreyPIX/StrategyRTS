
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.GameScenes;
using StrategyRTS.Shared;

namespace StrategyRTS
{
    public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private GameEngine engine;
		private GameSceneBase gameScene;
		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			graphics.PreferredBackBufferHeight = 1080;
			graphics.PreferredBackBufferWidth = 1920;
		}
		protected override void Initialize()
		{
			engine = new GameEngine();
			engine.HasShowCollider = false;
			gameScene = new GameScene1(engine, graphics);
			base.Initialize();
			gameScene.Initialize();
		}
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Globals.VideoCard = GraphicsDevice;
			gameScene.LoadContent(Content);
		}
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			engine.Update(gameTime);
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();
			gameScene.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
