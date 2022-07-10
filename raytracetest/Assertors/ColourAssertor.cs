namespace RayTraceTest.Assertors
{
    using RayTrace.Extensions;
    using RayTrace.Models;
    public static class ColourAssertor
    {
        public static void Assert(this Colour expected, double r, double g, double b)
        {
            Assert(r, expected.R,message:"R");
            Assert(g, expected.G,message:"G");
            Assert(b, expected.B,message:"B");
        }

        public static void Assert(this Colour expected, Colour actual)
        {
            expected.Assert(actual.R, actual.G, actual.B);
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