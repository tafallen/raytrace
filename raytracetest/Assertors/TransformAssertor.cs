namespace RayTraceTest.Assertors
{
    using RayTrace.Transforms;

    public static class TransformAssertor
    {
        public static void Assert(this Transformation actual, Transformation expected)
        {
            actual.Matrix.Assert(expected.Matrix);
        }
    }
}