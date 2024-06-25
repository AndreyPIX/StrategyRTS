
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Shared;
using System;

namespace StrategyRTS.ProceduralGeneration
{
    public class TextureGenerator
    {
        public static Texture2D CreateTextureBullet()
        {
            Color[] pixels =
            {
                Color.Transparent, Color.White, Color.Transparent,
                Color.White, Color.White, Color.White,
                Color.Transparent, Color.White, Color.Transparent
            };
            Texture2D texture = new Texture2D(Globals.VideoCard, 3, 3);
            texture.SetData(pixels);
            return texture;
        }
        public static Texture2D CreateFillTexture(int height, int width, Color color)
        {
            Color[] pixels = new Color[height * width];
            for (int i = 0; i < width * height; i++)
            {
                pixels[i] = color;
            }

            Texture2D texture = new Texture2D(Globals.VideoCard, width, height);
            texture.SetData(pixels);
            return texture;
        }
        public static Texture2D CreateTextureWhiteNoise(int height, int width, int extension)
        {
            float[,] noise = NoisesGenerator.GenerateWhiteNoise(height, width, extension);
            return GenerateTextureUsingAnArray(height, width, noise);
        }
        public static Texture2D CreateTextureWhiteNoiseBilinearlyInterpolated(int height, int width, int extension)
        {
            float[,] noise = NoisesGenerator.GenerateWhiteNoiseBilinearlyInterpolated(height, width, extension);
            return GenerateTextureUsingAnArray(height, width, noise);
        }
        public static Texture2D CreateTexturePerlinNoise(int height, int width)
        {
            float[,] noise = NoisesGenerator.GeneratePerlinNoise(height, width, 2);
            return GenerateTextureUsingAnArray(height, width, noise);
        }
        public static Texture2D CreateTexturePerlinNoiseBilinearlyInterpolated(int height, int width)
        {
            float[,] noise = NoisesGenerator.GeneratePerlinNoiseBilinearlyInterpolated(height, width, 2);
            return GenerateTextureUsingAnArray(height, width, noise);
        }
        private static Texture2D GenerateTextureUsingAnArray(int height, int width, float[,] noise)
        {
            Color[] pixels = new Color[height * width];
            for (int y = 0, i = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float color = noise[y, x];
                    pixels[i] = new Color(color, color, color);
                    i++;
                }
            }
            Texture2D texture = new Texture2D(Globals.VideoCard, width, height);
            texture.SetData(pixels);
            return texture;
        }
        public static Texture2D GenerateTexture(int width, Texture2D sideOfTexture)
        {
            int height = sideOfTexture.Height;
            int minWidth = sideOfTexture.Width * 2;
            if (minWidth > width)
                width = minWidth;
            Color[] sideOfSprite = new Color[sideOfTexture.Width * sideOfTexture.Height];
            sideOfTexture.GetData<Color>(sideOfSprite);
            Color[] sprite = new Color[width * height];
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
                    if (x + y * width < sideOfTexture.Width + y * width)
                        sprite[x + y * width] = sideOfSprite[x + y * width - (width - sideOfTexture.Width) * y];
                    else if (width - sideOfTexture.Width + width * y <= x + y * width && x + y * width < width + width * y)
						sprite[x + y * width] = sideOfSprite[sideOfSprite.Length - (x + y * width - (width - sideOfTexture.Width) * (y + 1)) - 1];
                    else
						sprite[x + y * width] = new Color(138, 138, 138);
				}
			}
			Texture2D texture = new Texture2D(Globals.VideoCard, width, height);
			texture.SetData(sprite);
			return texture;
		}

		public static Texture2D CreateTexturePixel()
		{
			Color[] pixels =
			{
				Color.White
			};
			
			Texture2D texture =
				new Texture2D(Globals.VideoCard, 1, 1);

			texture.SetData<Color>(pixels);

			return texture;
		}
	}
}
