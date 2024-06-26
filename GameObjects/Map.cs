
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;
using StrategyRTS.Shared;
using System.Collections.Generic;

namespace StrategyRTS.GameObjects
{
    public class Map : GameObject
    {
		private GraphicsDeviceManager graphics;
		public Vector2 SetPositionMapCenter
		{
			get
			{
				float x = graphics.PreferredBackBufferWidth / 2 - SizeCell * map.GetLength(1) * scale.X / 2;
				float y = graphics.PreferredBackBufferHeight / 2 - SizeCell * map.GetLength(0) * scale.Y / 2;
				return new Vector2(x, y);
			}
		}
		private List<GameObject> list = new List<GameObject>();
		private int minRenderingX;
		private int minRenderingY;
		private int maxRenderingX;
		private int maxRenderingY;
		/*private int sizeCell = 256;
		public int SizeCell
		{
			get{ return sizeCell;}
		}*/
        private int[,,] map;
		public int Height
		{
			get { return (int)(map.GetLength(0) * SizeCell * scale.Y); }
		}
		public int Width
		{
			get { return (int)(map.GetLength(1) * SizeCell * scale.X); }
		}
		public int SizeCell
		{
			get { return 256; }
		}
		public Map(GraphicsDeviceManager graphics)
		{
			this.graphics = graphics;
		}
		public void LoadMap(int[,] map)
		{
			this.map = new int[map.GetLength(0), map.GetLength(1), 2];
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					this.map[y, x, 0] = map[x, y];
					if (map[y, x] == 0)
						this.map[y, x, 1] = 0;
					if (map[y, x] == 1)
						this.map[y, x, 1] = 2;
				}
			}
		}
		public void SetPosition()
		{
			position = SetPositionMapCenter;
		}
        public void SetSizeMap(int width, int height)
        {
            map = new int[height, width, 2];
		}
        public void AddCell(GameObject gameObjects)
        {
            list.Add(gameObjects);
        }
		public void CreateMap(int countOctaves = 5)
        {
			GeneratorWorld world = new GeneratorWorld(map);
			map = world.ElevationGenerator(countOctaves);
			map = world.Smoothing(1, 0);
			map = world.Smoothing(0, 1);
			map = world.Smoothing(2, 1);
			map = world.Smoothing(1, 2);
			map = world.OverlappingСellsInHeight();
			map = world.ShoreGeneration();
		}
		private void Rendering()
		{
			minRenderingX = (int)((0 - position.X) / SizeCell);
			minRenderingY = (int)((0 - position.Y) / SizeCell);
			maxRenderingX = (int)((graphics.PreferredBackBufferWidth - position.X) / (SizeCell * scale.X) + 1);
			maxRenderingY = (int)((graphics.PreferredBackBufferHeight - position.Y) / (SizeCell * scale.Y) + 1);

			if (minRenderingY < 0)
				minRenderingY = 0;
			else if (minRenderingY > map.GetLength(0))
				minRenderingY = map.GetLength(0) - 1;

			if (maxRenderingY < 0)
				maxRenderingY = 0;
			else if (maxRenderingY > map.GetLength(0))
				maxRenderingY = map.GetLength(0) - 1;

			if (minRenderingX < 0)
				minRenderingX = 0;
			else if (minRenderingX > map.GetLength(0))
				minRenderingX = map.GetLength(1) - 1;

			if (maxRenderingX < 0)
				maxRenderingX = 0;
			else if (maxRenderingX > map.GetLength(0))
				maxRenderingX = map.GetLength(1) - 1;
		}
		public override void Draw(SpriteBatch spriteBatch)
        {
			Rendering();
			for (int y = minRenderingY; y < maxRenderingY; y++)
            {
				for (int x = minRenderingX; x < maxRenderingX; x++)
                {
                    list[map[y, x, 1]].SetPosition(new Vector2(scale.X * SizeCell * x + position.X, scale.Y * SizeCell * y + position.Y));
                    list[map[y, x, 1]].Scale = scale;
                    list[map[y, x, 1]].Draw(spriteBatch);
                }
            }
        }
		/*
        вода   id: 0
        песок  id: 1
        трава  id: 2
        камень id: -
        скала  id: 3
        */
	}
}
