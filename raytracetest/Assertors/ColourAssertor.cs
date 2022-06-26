namespace RayTraceTest.Assertors
{
    using RayTrace.Models;

    public static class ColourAssertor
    {
        public static void Assert(this Colour actual, double r, double g, double b)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(r, actual.R,message:"R");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(g, actual.G,message:"G");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(b, actual.B,message:"B");
        }

        public static void Assert(this Colour actual, Colour expected)
        {
            actual.Assert(expected.R, expected.G, expected.B);
        }
    }
}