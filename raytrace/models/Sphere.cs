namespace RayTrace.Models
{
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    public class Sphere : Element
    {
        public Point Origin{ get; set;}
        public double Radius {get; set;}
        public Transformation Transform {get; set;} 
        
        public Sphere() : base()
        {
            Origin = new Point(0,0,0);
            Radius = 1;
            Transform = Transformation.NullTransform;
        }
        public override string ToString()
        {
            return $"Sphere - Radius: {Radius}, Origin: {Origin}, Transform: {Transform}";
        }
        public Vector NormalAt(Point point)
        {
            Point objectPoint = Transform.Matrix.Inverse() * point;
            var objectNormal = objectPoint - this.Origin;
            var worldNormal = (Transform.Matrix.Inverse()).Transpose() * objectNormal;
            return worldNormal.Normalise();
        }
        public override Intersections Intersect(Ray r)
        {
            var ray = Transform != null ? Transform.Inverse().Transform(r) : r;

            var sphere_to_ray = ray.Point - Origin;
            var a = ray.Direction.DotProduct(ray.Direction);
            var b = 2 * (ray.Direction.DotProduct(sphere_to_ray));
            var c = (sphere_to_ray.DotProduct(sphere_to_ray)) -1;
            var discriminant = (b * b) - 4 * a * c;

            if( discriminant < 0)
                return new Intersections();

            var t1 = (-b - Math.Sqrt(discriminant)) / (2*a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2*a);

            var result = new Intersections();
            result.Add(new Intersection(t1, this));
            result.Add(new Intersection(t2, this));

            return result;
        }
    }
}