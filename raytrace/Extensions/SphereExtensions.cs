namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class SphereExtensions
    {
        public static Intersections Intersect(this Sphere sphere, Ray ray)
        {
            var sphere_to_ray = ray.Point - sphere.Origin;
            var a = ray.Direction.DotProduct(ray.Direction);
            var b = 2 * (ray.Direction.DotProduct(sphere_to_ray));
            var c = (sphere_to_ray.DotProduct(sphere_to_ray)) -1;
            var discriminant = (b * b) - 4 * a * c;

            if( discriminant < 0)
                return Intersections.List;

            var t1 = (-b - Math.Sqrt(discriminant)) / (2*a);
            var t2 = (-b + Math.Sqrt(discriminant)) / (2*a);

            Intersections.List.Add(new Intersection(t1, sphere));
            Intersections.List.Add(new Intersection(t2, sphere));

            return Intersections.List;
        }
    }
}
