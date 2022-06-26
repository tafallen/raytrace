namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class RayExtensions
    {
        public static Ray Transform(this Ray ray, Matrix matrix)
        {
            var p = RayTuple.Point(ray.Point.X + matrix[0,0], ray.Point.Y + matrix[0,1], ray.Point.Z + matrix[0,2]);
            return new Ray(p, ray.Direction);
        }
        public static Ray Scale(this Ray ray, Matrix matrix)
        {
            var p = RayTuple.Point(ray.Point.X * matrix[0,0], ray.Point.Y * matrix[0,1], ray.Point.Z * matrix[0,2]);
            var d = RayTuple.Vector(ray.Direction.X * matrix[0,0], ray.Direction.Y * matrix[0,1], ray.Direction.Z * matrix[0,2]);            
            return new Ray(p, d);
        }
        public static RayTuple Position( this Ray ray, double time)
        {
            return ray.Point + ray.Direction * time;
        }
    }
}
