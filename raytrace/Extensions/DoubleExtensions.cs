namespace RayTrace.Extensions
{
    public static class DoubleExtensions
    {
        public static double EPSILON = 0.000521;
        public static bool IsEqual(this double value, double other)
        {
            return( Math.Abs(value-other) < EPSILON );
        }
    }
}