using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayTrace.Models;

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

            actualResult.Assert(expectedResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Both Tuples may not be Point types")]
        public void TestAddPointPointFails()
        {
            var point = RayTuple.Point(3,-2,5);
            var vector = RayTuple.Point(-2,3,1);

            var actualResult = point + vector;
            var expectedResult = RayTuple.Point(1,1,6);

            actualResult.Assert(expectedResult);
        }
        
        [TestMethod]
        public void TestAddVectorVectorFails()
        {
            var vector1 = RayTuple.Vector(3,-2,5);
            var vector2 = RayTuple.Vector(-2,3,1);

            var actualResult = vector1 + vector2;
            var expectedResult = RayTuple.Vector(1,1,6);

            actualResult.Assert(expectedResult);
        }

        [TestMethod]
        public void TestSubtractPointPointSucceeds()
        {
            var point1 = RayTuple.Point(3,2,1);
            var point2 = RayTuple.Point(5,6,7);

            var expectedResult = RayTuple.Vector(-2,-4,-6);
            var actualResult = point1-point2;

            actualResult.Assert(expectedResult);
        }

        [TestMethod]
        public void TestSubtractPointVectorSuccess()
        {
            var point = RayTuple.Point(3,2,1);
            var vector = RayTuple.Vector(5,6,7);

            var expectedResult = RayTuple.Point(-2,-4,-6);
            var actualResult = point-vector;

            actualResult.Assert(expectedResult);
        }

        [TestMethod]
        public void TestSubtractVectorVectorSuccess()
        {
            var vector1 = RayTuple.Vector(3,2,1);
            var vector2 = RayTuple.Vector(5,6,7);

            var expectedResult = RayTuple.Vector(-2,-4,-6);
            var actualResult = vector1 - vector2;

            actualResult.Assert(expectedResult);
        }

        [TestMethod]
        public void TestNegateVectorSuccess()
        {
            var vector = RayTuple.Vector(1,-2,3);

            var expectedResult = RayTuple.Vector(-1,2,-3);
            var actualResult = !vector;

            actualResult.Assert(expectedResult);
        }
    }
}

