
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Controle;
using StrategyRTS.Shared;

namespace StrategyRTS.GameObjects
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
            scale = map.Scale;
        }

        public override void Update(GameTime gameTime)
        {
            for (int x = 0; x < graphics.PreferredBackBufferWidth; x++)
            {
                if (tempPosition.X < DrawingCoordinateFirstCell.X + (x + 1) * map.SizeCell * scale.X)
                {
                    position.X = DrawingCoordinateFirstCell.X + x * map.SizeCell * scale.X;
                    break;
                }
            }
            for (int y = 0; y < graphics.PreferredBackBufferHeight; y++)
            {
                if (tempPosition.Y < DrawingCoordinateFirstCell.Y + (y + 1) * map.SizeCell * scale.Y)
                {
                    position.Y = DrawingCoordinateFirstCell.Y + y * map.SizeCell * scale.Y;
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
