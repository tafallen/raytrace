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
    }
}

