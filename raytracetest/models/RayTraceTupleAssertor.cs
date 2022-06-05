using RayTrace.Models;

namespace RayTraceTest.Models
{
    public static class RayTraceTupleAssertor
    {
        public static void Assert(this RayTuple actual, double x, double y, double z, RayTupleType type)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(type, actual.Type);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(x, actual.X,message:"x");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(y, actual.Y,message:"y");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(z, actual.Z,message:"z");
        }

        public static void Assert(this RayTuple actual, RayTuple expected)
        {
            actual.Assert(expected.X, expected.Y, expected.Z, expected.Type);
        }
    }
}

