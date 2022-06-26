namespace RayTraceTest.Assertors
{
    using RayTrace.Models;

    public static class TransformAssertor
    {
        public static void Assert(this Transform actual, Transform expected)
        {
            actual.Matrix.Assert(expected.Matrix);
        }
    }
}