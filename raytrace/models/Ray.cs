namespace RayTrace.Models
{
    using RayTrace.Transforms;
    public class Ray
    {
        public Point Point{get; private set;}
        public Vector Direction{get; private set;}
        public Transformation Transform{get; set;}

        public Ray( Point point, Vector direction)
        {
            Transform = Transformation.NullTransform;

            if( point == null || 
                direction == null)
                throw new ArgumentException("Ray() constructor arguments cannot be null");

            Point = point;
            Direction = direction;
        }
    }
}