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
            var tuple = RayTuple.Point(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3, RayTupleType.Point);
        }
        [TestMethod]
        public void TestVector()
        {
            var tuple = RayTuple.Vector(0.1, 1.3, -4.3);

            tuple.Assert(0.1, 1.3, -4.3, RayTupleType.Vector);
        }
        [TestMethod]
        public void TestAddPointVectorSucceeds()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Vector(-2,3,1);

            RayTuple.Point(1,1,6)
                    .Assert(point + vector);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Both Tuples may not be Point types")]
        public void TestAddPointPointFails()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Point(-2,3,1);

            RayTuple.Point(1,1,6)
                    .Assert(point + vector);
        }
        [TestMethod]
        public void TestAddVectorVectorFails()
        {
            var vector1 = RayTuple.Vector(3,-2,5);
            var vector2 = RayTuple.Vector(-2,3,1);

            RayTuple.Vector(1,1,6)
                    .Assert(vector1 + vector2);
        }
        [TestMethod]
        public void TestSubtractPointPointSucceeds()
        {
            var point1 = RayTuple.Point(3,2,1);
            var point2 = RayTuple.Point(5,6,7);

            RayTuple.Vector(-2,-4,-6)
                    .Assert(point1-point2);
        }
        [TestMethod]
        public void TestSubtractPointVectorSuccess()
        {
            var point = RayTuple.Point(3,2,1);
            var vector = RayTuple.Vector(5,6,7);

            RayTuple.Point(-2,-4,-6)
                    .Assert(point-vector);
        }
        [TestMethod]
        public void TestSubtractVectorVectorSuccess()
        {
            var vector1 = RayTuple.Vector(3,2,1);
            var vector2 = RayTuple.Vector(5,6,7);

            RayTuple.Vector(-2,-4,-6)
                    .Assert(vector1 - vector2);
        }
        [TestMethod]
        public void TestNegateVectorSuccess()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(-1,2,-3)
                    .Assert(!vector);
        }
        [TestMethod]
        public void TestScalarMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(3.5, -7, 10.5)
                    .Assert(vector * 3.5);
        }
        [TestMethod]
        public void TestScalarFractionalMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(0.5, -1, 1.5)
                    .Assert(vector * 0.5);
        }
        [TestMethod]
        public void TestScalarDivisionSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            RayTuple.Vector(0.5, -1, 1.5)
                    .Assert(vector / 2);
        }
        [TestMethod]
        public void TestMagnitudeSucceeds()
        {
            var vector = RayTuple.Vector(0,1,0);

            var expectedResult = 1;

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestMagnitudeNegValuesSucceeds()
        {
            var vector = RayTuple.Vector(-1,2,-3);

            var expectedResult = Math.Sqrt(14);

            Assert.AreEqual(expectedResult, vector.Magnitude());
        }
        [TestMethod]
        public void TestNormalisationSucceeds()
        {
            var tuple = RayTuple.Vector(4,0,0);

            RayTuple.Vector(1,0,0)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestFractionalNormalisationSucceeds()
        {
            var tuple = RayTuple.Vector(1,2,3);
 
            RayTuple.Vector(0.2672612419124244,0.5345224838248488,0.8017837257372732)
                    .Assert(tuple.Normalise());
        }
        [TestMethod]
        public void TestDotProductSucceeds()
        {
            var vector1 = RayTuple.Vector(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            Assert.AreEqual(20, vector1.DotProduct(vector2));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "DotProduct() - Both tuples must be vectors")]
        public void TestDotProductPointFails()
        {
            var vector1 = RayTuple.Point(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            Assert.AreEqual(20, vector1.DotProduct(vector2));
        }
        [TestMethod]
        public void TestCrossProductSucceeds()
        {
            var vector1 = RayTuple.Vector(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            RayTuple.Vector(-1,2,-1)
                    .Assert(vector1.CrossProduct(vector2));

            RayTuple.Vector(1,-2,1)
                    .Assert(vector2.CrossProduct(vector1));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "CrossProduct() - Both tuples must be vectors")]
        public void TestCrossProductPointFails()
        {
            var vector1 = RayTuple.Point(1,2,3);
            var vector2 = RayTuple.Vector(2,3,4);

            RayTuple.Vector(-1,2,-1)
                    .Assert(vector1.CrossProduct(vector2));

            RayTuple.Vector(1,-2,1)
                    .Assert(vector2.CrossProduct(vector1));
        }
    }
}

