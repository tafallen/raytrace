using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTrace.Models;
using RayTrace.Extensions;

namespace RayTraceTest.Models
{
    [TestClass]
    public class RayTraceTupleTests
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

            var actualResult = point + vector;
            var expectedResult = RayTuple.Point(1,1,6);

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Both Tuples may not be Point types")]
        public void TestAddPointPointFails()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Point(-2,3,1);

            var actualResult = point + vector;
            var expectedResult = RayTuple.Point(1,1,6);

            expectedResult.Assert(actualResult);
        }
        
        [TestMethod]
        public void TestAddVectorVectorFails()
        {
            var vector1 = RayTuple.Vector(3,-2,5);
            var vector2 = RayTuple.Vector(-2,3,1);

            var actualResult = vector1 + vector2;
            var expectedResult = RayTuple.Vector(1,1,6);

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        public void TestSubtractPointPointSucceeds()
        {
            var point1 = RayTuple.Point(3,2,1);
            var point2 = RayTuple.Point(5,6,7);

            var expectedResult = RayTuple.Vector(-2,-4,-6);
            var actualResult = point1-point2;

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        public void TestSubtractPointVectorSuccess()
        {
            var point = RayTuple.Point(3,2,1);
            var vector = RayTuple.Vector(5,6,7);

            var expectedResult = RayTuple.Point(-2,-4,-6);
            var actualResult = point-vector;

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        public void TestSubtractVectorVectorSuccess()
        {
            var vector1 = RayTuple.Vector(3,2,1);
            var vector2 = RayTuple.Vector(5,6,7);

            var expectedResult = RayTuple.Vector(-2,-4,-6);
            var actualResult = vector1 - vector2;

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        public void TestNegateVectorSuccess()
        {
            var vector = RayTuple.Vector(1,-2,3);

            var expectedResult = RayTuple.Vector(-1,2,-3);
            var actualResult = !vector;

            expectedResult.Assert(actualResult);
        }

        [TestMethod]
        public void TestScalarMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            var expectedResult = RayTuple.Vector(3.5, -7, 10.5);

            expectedResult.Assert(vector * 3.5);
        }

        [TestMethod]
        public void TestScalarFractionalMultiplicationSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            var expectedResult = RayTuple.Vector(0.5, -1, 1.5);

            expectedResult.Assert(vector * 0.5);
        }

        [TestMethod]
        public void TestScalarDivisionSucceeds()
        {
            var vector = RayTuple.Vector(1,-2,3);

            var expectedResult = RayTuple.Vector(0.5, -1, 1.5);

            expectedResult.Assert(vector / 2);
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
    }
}

