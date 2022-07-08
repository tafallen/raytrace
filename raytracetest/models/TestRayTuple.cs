namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestRayTraceTuple
    {
        [TestMethod]
        public void TestPoint()
        {
            var tuple = new Point(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3);
        }
        [TestMethod]
        public void TestVector()
        {
            var tuple = new Vector(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3);
        }
        [TestMethod]
        public void TestAddPointVectorSucceeds()
        {
            var point = new Point(3,-2,5);
            var vector = new Vector(-2,3,1);

            new Point(1,1,6)
               .Assert(point + vector);
        }
        [TestMethod]
        public void TestAddVectorVectorFails()
        {
            var vector1 = new Vector(3,-2,5);
            var vector2 = new Vector(-2,3,1);

            new Vector(1,1,6)
               .Assert(vector1 + vector2);
        }
        [TestMethod]
        public void TestSubtractPointPointSucceeds()
        {
            var point1 = new Point(3,2,1);
            var point2 = new Point(5,6,7);

            new Vector(-2,-4,-6)
               .Assert(point1-point2);
        }
        [TestMethod]
        public void TestSubtractPointVectorSuccess()
        {
            var point = new Point(3,2,1);
            var vector = new Vector(5,6,7);

            new Point(-2,-4,-6)
               .Assert(point-vector);
        }
        [TestMethod]
        public void TestSubtractVectorVectorSuccess()
        {
            var vector1 = new Vector(3,2,1);
            var vector2 = new Vector(5,6,7);

            new Vector(-2,-4,-6)
               .Assert(vector1 - vector2);
        }
        [TestMethod]
        public void TestNegateVectorSuccess()
        {
            var vector = new Vector(1,-2,3);

            new Vector(-1,2,-3)
               .Assert(!vector);
        }
        [TestMethod]
        public void TestScalarMultiplicationSucceeds()
        {
            var vector = new Vector(1,-2,3);

            new Vector(3.5, -7, 10.5)
               .Assert(vector * 3.5);
        }
        [TestMethod]
        public void TestScalarFractionalMultiplicationSucceeds()
        {
            var vector = new Vector(1,-2,3);

            new Vector(0.5, -1, 1.5)
               .Assert(vector * 0.5);
        }
        [TestMethod]
        public void TestScalarDivisionSucceeds()
        {
            var vector = new Vector(1,-2,3);

            new Vector(0.5, -1, 1.5)
               .Assert(vector / 2);
        }
        [TestMethod]
        public void TestMagnitudeSucceeds()
        {
            var vector = new Vector(0,1,0);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestMagnitudeNegValuesSucceeds()
        {
            var vector = new Vector(-1,2,-3);
            var expectedResult = Math.Sqrt(14);

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestNormalisationSucceeds()
        {
            var tuple = new Vector(4,0,0);
            new Vector(1,0,0)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestFractionalNormalisationSucceeds()
        {
            var tuple = new Vector(1,2,3);
 
            new Vector(0.2672612419124244,0.5345224838248488,0.8017837257372732)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestDotProductSucceeds()
        {
            var vector1 = new Vector(1,2,3);
            var vector2 = new Vector(2,3,4);

            Assert.AreEqual(20, vector1.DotProduct(vector2));
        }
        [TestMethod]
        public void TestCrossProductSucceeds()
        {
            var vector1 = new Vector(1,2,3);
            var vector2 = new Vector(2,3,4);

            new Vector(-1,2,-1)
                    .Assert(vector1.CrossProduct(vector2));

            new Vector(1,-2,1)
                    .Assert(vector2.CrossProduct(vector1));
        }
        [TestMethod]
        public void Reflect45degVector()
        {
            var vector = new Vector(1, -1, 0);
            var normal = new Vector(0, 1, 0);
            var expected = new Vector(1, 1, 0);

            expected.Assert(vector.Reflect(normal));
        }
        [TestMethod]
        public void ReflectOffSlantedSurface()
        {
            var vector = new Vector(0, -1, 0);
            var normal = new Vector(Math.Sqrt(2)/2, Math.Sqrt(2)/2, 0);
            var expected = new Vector(1, 0, 0);

            expected.Assert(vector.Reflect(normal));
        }
    }
}

