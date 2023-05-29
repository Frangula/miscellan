using ObjectAreaLib;

namespace ObjectAreaLib_Tests
{
    [TestClass]
    public class FigureAreaTests
    {
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
            double[] sides = new[] { 5d, 0d, 0d};

            Assert.ThrowsException<NotImplementedException>(() => FigureArea.GetTriangleArea(sides));
        }
    }
}