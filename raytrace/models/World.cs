namespace RayTrace.Models
{
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    public class World
    {
        public List<Element> Elements {get;set;}
        public Light? Light {get;set;}

        public World()
        {
            Elements = new List<Element>();
        }
    }
}