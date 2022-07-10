namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class RayExtensions
    {
        public static Point Position(this Ray ray, double time)
        {
            return ray.Point + ray.Direction * time;
        }
    }
}
