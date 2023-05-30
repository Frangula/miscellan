using ObjectAreaLib;
using System.Diagnostics.SymbolStore;

namespace ObjectAreaLib_Tests
{
    [TestClass]
    public class FigureAreaTests
    {
        [TestMethod]
        public void IsRightTriangle_RightTriangleSides_True()
        {
            double[] sides = new[] { 3d, 5d, 4d };
            bool expected = true;

            bool result = FigureArea.IsRightTriangle(sides);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsRightTriangle_SimpleTriangleSides_False()
        {
            double[] sides = new[] { 2d, 5d, 4d };
            bool expected = false;

            bool result = FigureArea.IsRightTriangle(sides);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void IsEquletiral_EqualSides_True()
        {
            double[] sides = new[] { 3d, 3d, 3d };
            bool expected = true;

            bool result = FigureArea.IsEquilateral(sides);

            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void IsEquletiral_UnequalSides_False()
        {
            double[] sides = new[] { 3d, 8d, 5d };
            bool expected = false;

            bool result = FigureArea.IsEquilateral(sides);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCircleArea_ValidRadius_ComputesArea()
        {
            double radius = 2;
            double expected = 12.56637;
            double delta = 0.0001;

            double area = FigureArea.GetCircleArea(radius);

            Assert.AreEqual(expected, area, delta);
        }
        [TestMethod]
        public void GetCircleArea_InvalidRadius_Throws()
        {
            double radius = 0;

            Assert.ThrowsException<ArgumentException>(() => FigureArea.GetCircleArea(radius));
        }

        [TestMethod]
        public void GetTriangleArea_ValidSides_ComputesArea()
        {
            double[] sides = new[] { 2d, 5, 3.6d };
            double expexted = 2.9866;
            double delta = 0.0001;

            double area = FigureArea.GetTriangleArea(sides);

            Assert.AreEqual(expexted, area, delta);
        }

        [TestMethod]
        public void GetCircleArea_MoreThanThreeSides_Throws()
        {
            double[] sides = new[] { 1d, 1d, 1d, 1d, 1d };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => FigureArea.GetTriangleArea(sides));
        }
        [TestMethod]
        public void GetCircleArea_EmptySides_Throws()
        {
            double[] sides = null;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => FigureArea.GetTriangleArea(sides));
        }
        [TestMethod]
        public void GetCircleArea_OneSide_Throws()
        {
            double[] sides = new[] { 2d };

            Assert.ThrowsException<NotImplementedException>(() => FigureArea.GetTriangleArea(sides));
        }
        [TestMethod]
        public void GetCircleArea_TwoSides_Throws()
        {
            double[] sides = new[] { 5, 3.6d };

            Assert.ThrowsException<NotImplementedException>(() => FigureArea.GetTriangleArea(sides));
        }
        [TestMethod]
        public void GetCircleArea_OneSideTwoZeros_Throws()
        {
            double[] sides = new[] { 5d, 0d, 0d };

            Assert.ThrowsException<NotImplementedException>(() => FigureArea.GetTriangleArea(sides));
        }

        [TestMethod]
        public void GetPolygonArea_FourPoints_ComputesArea()
        {
            (double, double)[] sides = new[]
            {
                (4d, 10d),
                (9d, 7d),
                (11d, 2d),
                (2d, 2d)
            };
            double expexted = 45.5;
            double delta = 0.0001;

            double area = FigureArea.GetPolygonArea(sides);

            Assert.AreEqual(expexted, area, delta);
        }
    }
}