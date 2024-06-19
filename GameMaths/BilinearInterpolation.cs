
namespace StrategyRTS.GameMaths
{
	public class BilinearInterpolation
	{
		private static int ShiftX(int x, int shift)
		{
			return x / shift * shift;
		}
		private static int ShiftY(int y, int shift)
		{
			return y / shift * shift;
		}
		public static float BilinearInterpolationFormula(float[,] heights, int width, int height, int x, int y, int shift)
		{
			int shiftX = ShiftX(x, shift);
			int shiftY = ShiftY(y, shift);
			float z1 = heights[shiftY, shiftX];
			float z2 = heights[shiftY, (shiftX + shift) % width];
			float z3 = heights[(shiftY + shift) % height, shiftX];
			float z4 = heights[(shiftY + shift) % height, (shiftX + shift) % width];
			float formX1 = InterpolateFormula1(x, shift, width);
			float formX2 = InterpolateFormula2(x, shift, width);
			float zx1 = formX1 * z1 + formX2 * z2;
			float zx2 = formX1 * z3 + formX2 * z4;
			float formY1 = InterpolateFormula1(y, shift, width);
			float formY2 = InterpolateFormula2(y, shift, width);
			float zy1 = formY1 * zx1 + formY2 * zx2;
			return zy1;
		}
		public static float InterpolateFormula1(int focalPoint, int scale, int distance)
		{
			return (float)((focalPoint / scale * scale + scale) % distance - focalPoint)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
		public static float InterpolateFormula2(int focalPoint, int scale, int distance)
		{
			return (float)(focalPoint - focalPoint / scale * scale)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
	}
}
