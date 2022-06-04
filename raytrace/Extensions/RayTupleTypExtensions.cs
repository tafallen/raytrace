namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class RayTupleTypeExtensions
    {
        public static RayTupleType Add(this RayTupleType a, RayTupleType b)
        {
            if( a == RayTupleType.Point && b == RayTupleType.Point)
            {
                throw new ArgumentException("Both Tuples may not be Point types");
            }
            return (RayTupleType)((int)a + (int)b);
        }

        public static RayTupleType Subtract(this RayTupleType a, RayTupleType b)
        {
            return (RayTupleType)((int)a - (int)b);
        }
    }
}