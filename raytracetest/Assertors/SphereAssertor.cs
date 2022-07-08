namespace RayTraceTest.Assertors
{
    using RayTrace.Models;

    public static class SphereAssertor
    {
        public static void Assert(this Sphere actual, Sphere expected)
        {
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(expected);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(actual.Radius, expected.Radius); 
            actual.Origin.Assert(expected.Origin);
            actual.Transform.Assert(expected.Transform);
        }
    }
}