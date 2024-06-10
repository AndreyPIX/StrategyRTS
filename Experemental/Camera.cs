﻿
using Microsoft.Xna.Framework;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Experemental
{
    public class Camera : GameObject
    {
        private int width;
        public int Width
        {
            get { return width; }
        }
        private int height;
		public int Height
		{
			get { return height; }
		}

		public Camera(GraphicsDeviceManager graphics)
        {
            DefaultSetting();
			height = graphics.PreferredBackBufferHeight / 4;
			width = graphics.PreferredBackBufferWidth / 4;
        }
    }
}
