namespace RayTrace.Models
{
    using RayTrace.Extensions;
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
        public bool IsShadowed(Point point)
        {
            var v = this.Light.Position - point;
            var distance = v.Magnitude();
            var direction = v.Normalise();

            var ray = new Ray(point, direction);
            var intersections = Intersect(ray);

            var h = intersections.Hit();
            if(h!= null && h.T < distance)
                return true;
            else 
                return false;
        }
    }
}