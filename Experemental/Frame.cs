﻿
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using StrategyRTS.Shared;

namespace StrategyRTS.Experemental
{
	public class Frame : GameObject
	{
		private GraphicsDeviceManager graphics;
		private Map map;
		private Vector2 DrawingCoordinateFirstCell
		{
			get
			{
				float x = map.Position.X - (int)(map.Position.X / map.SizeCell) * map.SizeCell;
				float y = map.Position.Y - (int)(map.Position.Y / map.SizeCell) * map.SizeCell;
				return new Vector2(x, y);
			}
		}

		public Frame(Texture2D texture, GraphicsDeviceManager graphics, Map map) : base(texture)
		{
			this.map = map;
			this.graphics = graphics; 
		}
		
		public override void Update(GameTime gameTime)
		{
			for (int x = 0; x < graphics.PreferredBackBufferWidth; x++)
			{
				if (tempPosition.X < DrawingCoordinateFirstCell.X + (x + 1) * map.SizeCell)
				{
					position.X = DrawingCoordinateFirstCell.X + x * map.SizeCell;
					break;
				}
			}
			for (int y = 0; y < graphics.PreferredBackBufferWidth; y++)
			{
				if (tempPosition.Y < DrawingCoordinateFirstCell.Y + (y + 1) * map.SizeCell)
				{
					position.Y = DrawingCoordinateFirstCell.Y + y * map.SizeCell;
					break;
				}
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
