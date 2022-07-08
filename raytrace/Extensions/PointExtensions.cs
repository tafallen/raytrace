namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class PointExtensions
    {
        public static double Magnitude(this Point tuple)
        {
            return Math.Sqrt(
                Math.Pow(Math.Abs(tuple.X),2) + 
                Math.Pow(Math.Abs(tuple.Y),2) +
                Math.Pow(Math.Abs(tuple.Z),2));
        }
        public static Point Normalise(this Point tuple)
        {
            var magnitude = tuple.Magnitude();
            var x = tuple.X/magnitude;
            var y = tuple.Y/magnitude;
            var z = tuple.Z/magnitude;
            return new Point(x, y, z);
        }
        public static double DotProduct(this Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        public static Vector CrossProduct(this Vector a, Vector b)
        {
            var x = a.Y * b.Z - a.Z * b.Y;
            var y = a.Z * b.X - a.X * b.Z;
            var z = a.X * b.Y - a.Y * b.X;

            return new Vector(x,y,z);
        }
    }
}