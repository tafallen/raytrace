namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class RayTupleExtensions
    {
        public static double Magnitude(this RayTuple tuple)
        {
            return Math.Sqrt(
                Math.Pow(Math.Abs(tuple.X),2) + 
                Math.Pow(Math.Abs(tuple.Y),2) +
                Math.Pow(Math.Abs(tuple.Z),2));
        }

        public static RayTuple Normalise(this RayTuple tuple)
        {
            var magnitude = tuple.Magnitude();
            var x = tuple.X/magnitude;
            var y = tuple.Y/magnitude;
            var z = tuple.Z/magnitude;
            return new RayTuple(x, y, z, tuple.Type);
        }

        public static double DotProduct(this RayTuple a, RayTuple b )
        {
            if( a.Type != RayTupleType.Vector || b.Type != RayTupleType.Vector)
                throw new ArgumentException("DotProduct() - Both tuples must be vectors");

            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }
    }
}