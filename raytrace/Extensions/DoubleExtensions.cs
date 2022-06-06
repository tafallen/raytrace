namespace RayTrace.Extensions
{
    public static class DoubleExtensions
    {
        public static double EPSILON = 0.00001; 
        public static bool IsEqual(this double value, double other)
        {
            if( Math.Abs(value-other) < EPSILON )
                return true;
            return false;
        }
    }
}