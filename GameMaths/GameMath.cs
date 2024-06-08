
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;

namespace StrategyRTS.GameMaths
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
		public static void DrawRectangle(SpriteBatch batch, int left, int top, int width, int height, Color color, int thickness = 1)
		{
			Vector2 scaleHorizontal = new Vector2(width, thickness);
			Vector2 scaleVertical = new Vector2(thickness, height);

			Vector2 originHorizontal = new Vector2(0.0f, 0.5f);
			Vector2 originVertical = new Vector2(0.5f, 0.0f);

			batch.Draw(Pixel, new Vector2(left, top), null, color, 0, originHorizontal, scaleHorizontal, SpriteEffects.None, 1);
			
			batch.Draw(Pixel, new Vector2(left, top + height), null, color, 0, originHorizontal, scaleHorizontal, SpriteEffects.None, 1);

			batch.Draw(Pixel, new Vector2(left, top), null, color, 0, originVertical, scaleVertical, SpriteEffects.None, 1);
			
			batch.Draw(Pixel, new Vector2(left + width, top), null, color, 0,  originVertical, scaleVertical, SpriteEffects.None, 1);
		}

		public static void DrawRectangle(SpriteBatch batch, Rectangle rectangle, Vector2 center, Color color, int thickness = 1)
		{
			DrawRectangle(batch, (int)(center.X - rectangle.Width / 2), (int)(center.Y - rectangle.Height / 2), rectangle.Width, rectangle.Height, color, thickness);
		}
	}
}
