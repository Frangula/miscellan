using System;
using System.Diagnostics.SymbolStore;

namespace ObjectAreaLib
{
    public static class FigureArea
    {
        /// <summary>
        /// Determine if triangle is equilateral.
        /// </summary>
        /// <param name="items"></param>
        /// <returns><c>true</c> if all triangle sides are equal.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsEquilateral(float[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length < 3)
                throw new ArgumentOutOfRangeException(nameof(items));
            return !items.Any(o => o != items[0]);
        }

        /// <summary>
        /// This method calculates circle area by its radius.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Throws if radius < 0.
        /// </exception>
        public static double GetCircleArea(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException(nameof(radius), "Radius must be more than 0.");
            return MathF.PI * Math.Pow(radius, 2);
        }
        /// <summary>
        /// This method calculates triangle area.
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when param sides is null or contains more than 3 elements.
        /// </exception>
        /// <exception cref="NotImplementedException"></exception>
        public static double GetTriangleArea(double[] sides)
        {
            if (sides == null || sides.Length > 3)
                throw new ArgumentOutOfRangeException(nameof(sides));

            if (sides.Length == 1 || sides.Count(s => s <= 0d) > 1)
            {
                throw new NotImplementedException("Calculating the area of an equilateral triangle by single side are not supported.");
            }
            if (sides.Length == 2 || sides.Any(s => s <= 0d))
            {
                throw new NotImplementedException("Calculating the area of a triangle by height and base are not supported.");
            }
            if (sides.Length == 3)
            {
                double semiP = (sides[0] + sides[1] + sides[2]) / 2f;
                return Math.Sqrt(semiP * (semiP - sides[0]) * (semiP - sides[1]) * (semiP - sides[2]));
            }
            return -1;
        }
    }
}
