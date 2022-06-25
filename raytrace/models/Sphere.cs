namespace RayTrace.Models
{
    using RayTrace.Extensions;

    public class Sphere : Element
    {
        public RayTuple Origin{ get; set;}
        public double Radius {get; set;}

        public Sphere()
        {
            Origin = RayTuple.Point(0,0,0);
            Radius = 1;
        }
        public Intersections Intersect(Ray ray)
        {
            var sphere_to_ray = ray.Point - Origin;
            var a = ray.Direction.DotProduct(ray.Direction);
            var b = 2 * (ray.Direction.DotProduct(sphere_to_ray));
            var c = (sphere_to_ray.DotProduct(sphere_to_ray)) -1;
            var discriminant = (b * b) - 4 * a * c;

            if( discriminant < 0)
                return Intersections.List;

            var t1 = (-b - Math.Sqrt(discriminant)) / (2*a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2*a);

            Intersections.List.Add(new Intersection(t1, this));
            Intersections.List.Add(new Intersection(t2, this));

            return Intersections.List;
        }
    }
}