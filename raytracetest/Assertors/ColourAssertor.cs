namespace RayTraceTest.Assertors
{
    using RayTrace.Extensions;
    using RayTrace.Models;
    public static class ColourAssertor
    {
        public static void Assert(this Colour actual, double r, double g, double b)
        {
            Assert(r, actual.R,message:"R");
            Assert(g, actual.G,message:"G");
            Assert(b, actual.B,message:"B");
        }

        public static void Assert(this Colour actual, Colour expected)
        {
            actual.Assert(expected.R, expected.G, expected.B);
        }
        public static void Assert(double expected, double actual, string message)
        {
            if(!expected.IsEqual(actual))
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail( $"Assert.IsEqual() failed. Expected:<{expected}>. Actual:<{actual}> {message}");
            }
        }
    }
}