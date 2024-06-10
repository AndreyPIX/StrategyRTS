
using Microsoft.Xna.Framework;

namespace StrategyRTS.GameObjects
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

        public Camera(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Camera(GraphicsDeviceManager graphics)
        {
            DefaultSetting();
            height = graphics.PreferredBackBufferHeight / 4;
            width = graphics.PreferredBackBufferWidth / 4;
        }
    }
}
