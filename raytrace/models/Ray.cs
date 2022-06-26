namespace RayTrace.Models
{
    using RayTrace.Transforms;
    using RayTrace.Extensions;

    public class Ray
    {
        public RayTuple Point{get; private set;}
        public RayTuple Direction{get; private set;}
        public BasicTransform Transform{get; set;}

        public Ray( RayTuple point, RayTuple direction)
        {
            Transform = BasicTransform.NullTransform;

            if( point == null || 
                direction == null || 
                point.Type != RayTupleType.Point || 
                direction.Type != RayTupleType.Vector)
                throw new ArgumentException("Ray() constructor arguments cannot be null");

            Point = point;
            Direction = direction;
        }
    }
}