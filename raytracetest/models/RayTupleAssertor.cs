namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    public static class RayTupleAssertor
    {
        public static void Assert(this RayTuple actual, double x, double y, double z, RayTupleType type)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(type, actual.Type);
            Assert(x, actual.X,message:"x");
            Assert(y, actual.Y,message:"y");
            Assert(z, actual.Z,message:"z");
        }

        public static void Assert(this RayTuple actual, RayTuple expected)
        {
            actual.Assert(expected.X, expected.Y, expected.Z, expected.Type);
        }

        public static void Assert(double expected, double actual, string message = "")
        {
            if(!expected.IsEqual(actual))
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail( $"Assert.IsEqual() failed. Expected:<{expected}>. Actual:<{actual}> {message}");
            }
        }
    }
}

