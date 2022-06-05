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
            Console.WriteLine($"mag: {magnitude}");
            var x = tuple.X/magnitude;
            var y = tuple.Y/magnitude;
            var z = tuple.Z/magnitude;
            Console.WriteLine($"({x},{y},{z})");
            return new RayTuple(x, y, z, tuple.Type);

        }
    }
}