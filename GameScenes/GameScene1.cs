
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;
using StrategyRTS.Controle;
using StrategyRTS.Experemental;
using StrategyRTS.GameObjects;
using StrategyRTS.ProceduralGeneration;
using System.Net;

namespace StrategyRTS.GameScenes
{
    public class GameScene1 : GameSceneBase
	{
		private Texture2D textureWater;
		private Texture2D textureSand;
		private Texture2D textureGrass;
		private Texture2D textureStone;
		private Texture2D textureRock;

		private Texture2D textureFrame;

		public GameScene1(GameEngine engine, GraphicsDeviceManager graphics) : base(engine, graphics)
		{

		}
		public override void Initialize()
		{
			Vector2 scale = new Vector2(1f);

			GameObject water = new GameObject(textureWater);
			GameObject sand = new GameObject(textureSand);
			GameObject grass = new GameObject(textureGrass);
			GameObject stone = new GameObject(textureStone);
			GameObject rock = new GameObject(textureRock);
			
			Map map = new(graphics);
			map.Scale = scale;
			map.SetSizeMap(256 * 2, 256 * 2);

			map.AddCell(water);
			map.AddCell(sand);
			map.AddCell(grass);
			map.AddCell(rock);

			map.CreateMap(7);
			map.SetPosition();
			map.CollisionIndex = 0;
			map.AddCollider<RentangleColliderMap>();

			Camera camera = new Camera(graphics);
			camera.SetPosition(new Vector2(0, 0));
			camera.NullTexture();
			camera.CollisionIndex = 0;
            camera.AddCollider<RentangleColliderCamera>();

			KeyboardCameraController cameraControlle = new KeyboardCameraController(new KeyboardLayoutCameraControle());
			cameraControlle.Attach(map);


			Frame frame = new Frame(textureFrame, graphics, map);
			frame.Scale = scale;

			MouseControllerFollow mouse1 = new MouseControllerFollow();
			mouse1.Attach(frame);

			engine.Add(map);
			engine.Add(camera);
			engine.Add(cameraControlle);
			engine.Add(frame);
			engine.Add(mouse1);
		}
		public override void LoadContent(ContentManager content)
		{
			textureWater = content.Load<Texture2D>("png/Relief/Water");
			textureSand = content.Load<Texture2D>("png/Relief/Sand");
			textureGrass = content.Load<Texture2D>("png/Relief/Grass");
			textureStone = content.Load<Texture2D>("png/Relief/Stone");
			textureRock = content.Load<Texture2D>("png/Relief/Rock");
			textureFrame = content.Load<Texture2D>("png/UserInterface/Frame");


		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
