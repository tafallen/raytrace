namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class RayTupleExtensions
    {
        public static double Magnitude( this RayTuple tuple)
        {
            return Math.Sqrt(
                Math.Pow(Math.Abs(tuple.X),2) + 
                Math.Pow(Math.Abs(tuple.Y),2) +
                Math.Pow(Math.Abs(tuple.Z),2));
        }
    }
}