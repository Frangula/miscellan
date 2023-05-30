using System;
using System.Diagnostics.SymbolStore;

namespace ObjectAreaLib
{
    public static class FigureArea
    {
        /// <summary>
        /// Determine if triangle has 90 degree angle.
        /// </summary>
        /// <param name="items"></param>
        /// <returns><c>true</c> if triangle have 90 degree angle.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsRightTriangle(double[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(items));
            double hypo = items.Max();

            return Math.Pow(items.Max(), 2) == items.Where(x => x < hypo).Sum(x => Math.Pow(x, 2));
        }
        /// <summary>
        /// Determine if triangle is equilateral.
        /// </summary>
        /// <param name="items"></param>
        /// <returns><c>true</c> if all triangle sides are equal.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool IsEquilateral(double[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (items.Length != 3)
                throw new ArgumentOutOfRangeException(nameof(items));
            return !items.Any(o => o != items[0]);
        }

        /// <summary>
        /// This method calculates the area of a circle by its radius.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// Throws if radius < 0.
        /// </exception>
        public static double GetCircleArea(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius must be more than 0.", nameof(radius));
            return MathF.PI * Math.Pow(radius, 2);
        }
        /// <summary>
        /// This method calculates the area of a triangle.
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
        /// <summary>
        /// Calculates the n-gon area.
        /// </summary>
        /// <param name="points">Polygon vertex coordinates.</param>
        /// <returns></returns>
        public static double GetPolygonArea((double, double)[] points)
        {
            if (points.Length < 3)
                throw new ArgumentException(nameof(points));
            double area = 0d;
            int numItems = points.Length;
            for (int i = 0; i < numItems - 1; i++)
            {
                area += points[i].Item1 * points[i + 1].Item2 - points[i + 1].Item1 * points[i].Item2;
            }
            area += points[numItems - 1].Item1 * points[0].Item2 - points[0].Item1 * points[numItems - 1].Item2;
            return Math.Abs(area) / 2d;
        }

        public enum Input
        {
            Point,
            Side
        }
        public enum Shape
        {
            Polygon = 0,
            Circle = 1,
            Triangle = 2,
        }
    }
}
