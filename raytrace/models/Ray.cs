namespace RayTrace.Models
{
    using RayTrace.Extensions;

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
        public Ray Transform(Matrix matrix)
        {
            var p = RayTuple.Point(Point.X + matrix.GetElement(0,0), Point.Y + matrix.GetElement(0,1), Point.Z + matrix.GetElement(0,2));
            return new Ray(p, Direction);
        }
        public Ray Scale(Matrix matrix)
        {
            var p = RayTuple.Point(Point.X * matrix.GetElement(0,0), Point.Y * matrix.GetElement(0,1), Point.Z * matrix.GetElement(0,2));
            var d = RayTuple.Vector(Direction.X * matrix.GetElement(0,0), Direction.Y * matrix.GetElement(0,1), Direction.Z * matrix.GetElement(0,2));            
            return new Ray(p, d);
        }
    }
}