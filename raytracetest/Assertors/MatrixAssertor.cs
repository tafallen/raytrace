namespace RayTraceTest.Assertors
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    public static class MatrixAssertor
    {
        public static void Assert(this Matrix expected, Matrix actual)
        {
            for(var i=0; i<expected.GetDimensions().x; i++)
                for(var j=0; j<expected.GetDimensions().y; j++)
                {
                    Assert(expected, actual, i, j);
                }
        }
        public static void Assert(Matrix expected, Matrix actual, int i, int j)//string message = "")
        {
            var e = expected.GetElement(i,j) ;
            var a = actual.GetElement(i,j);

            if(!e.IsEqual(a))
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail( $"Assert.IsEqual() failed. Expected:<{expected}>. Actual:<{actual}> - Location[{i},{j}]");
            }
        }
    }
}