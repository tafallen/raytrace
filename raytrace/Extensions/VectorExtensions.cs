namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class VectorExtensions
    {
        public static double Magnitude(this Vector tuple)
        {
            return Math.Sqrt(
                Math.Pow(Math.Abs(tuple.X),2) + 
                Math.Pow(Math.Abs(tuple.Y),2) +
                Math.Pow(Math.Abs(tuple.Z),2));
        }
        public static Vector Normalise(this Vector tuple)
        {
            var magnitude = tuple.Magnitude();
            var x = tuple.X/magnitude;
            var y = tuple.Y/magnitude;
            var z = tuple.Z/magnitude;
            return new Vector(x, y, z);
        }
        public static Vector Reflect(this Vector a, Vector normal)
        {
            return a - normal * 2d * a.DotProduct(normal);
        }
    }
}