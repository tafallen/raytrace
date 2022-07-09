namespace RayTrace.Models
{
    public class World
    {
        public List<Element> Elements {get;set;}
        public Light Light {get;set;}

        public World()
        {
            Elements = new List<Element>();
            Light = new Light();
        }

        public Intersections Intersect(Ray ray)
        {
            Intersections result = new Intersections();
            foreach(var item in Elements)
            {
                result.AddRange(item.Intersect(ray));
            }
            return result;
        }

        public Colour ShadeHit(Comps comps)
        {
            return comps.Element.Material.Lighting(Light, comps.Point, comps.EyeV, comps.NormalV);
        }

        public Colour ColourAt(Ray ray)
        {
            var list= Intersect(ray);
            var hit = list.Hit();

            if( hit != null )
            {
                var comps = hit.PrepareComputations(ray);
                return ShadeHit(comps);
            }
            return new Colour(0,0,0);
        }
    }
}