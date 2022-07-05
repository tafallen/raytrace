namespace RayTrace.Models
{
    public abstract class Element
    {
        public Material Material{ get; set; }

        public abstract Intersections Intersect(Ray r);
    }
}