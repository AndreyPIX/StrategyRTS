using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;
using System.Windows.Forms;

namespace StrategyRTS.GameMath
{
    public class GameMath
    {
		private static Texture2D pixel;
		public static Texture2D Pixel
		{
			get
			{
				if (pixel == null)
				{
					pixel = TextureGenerator.CreateTexturePixel();
				}
				return pixel;
			}
		}
        public static void DrawRectangle(SpriteBatch spriteBatch, int left, int top, int width, int height, Color color, int thickness = 1)
        {
			Vector2 scaleHorizontal = new Vector2(width, thickness);
			Vector2 scaleVertical = new Vector2(thickness, height);
			Vector2 originHorizontal = new Vector2(0.0f, 0.5f);
			Vector2 originVertical = new Vector2(0.5f, 0.0f);
			spriteBatch.Draw(Pixel, new Vector2(left, top), null, color, 0, originHorizontal, scaleHorizontal, SpriteEffects.None, 1);
		}
	}
}
