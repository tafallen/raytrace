namespace RayTrace.Models
{
    public class Ray
    {
        public RayTuple Point{get; private set;}
        public RayTuple Direction{get; private set;}

        public Ray( RayTuple point, RayTuple direction)
        {
            if( point == null || 
                direction == null || 
                point.Type != RayTupleType.Point || 
                direction.Type != RayTupleType.Vector)
                throw new ArgumentException("Ray() constructor arguments cannot be null");

            this.Point = point;
            this.Direction = direction;
        }
        public RayTuple Position(double time)
        {
            return Point + Direction * time;
        }
    }
}