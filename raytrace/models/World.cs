namespace RayTrace.Models
{
    using RayTrace.Extensions;
    public class World
    {
        private List<Element> Elements {get;set;}
        public Light Light {get;set;}
        public World()
        {
            Elements = new List<Element>();
            Light = new Light();
        }
        public void Add(Element element)
        {
            Elements.Add(element);
        }
        public IReadOnlyCollection<Element> GetElements()
        {
            return Elements.AsReadOnly();
        }
        public Intersections Intersect(Ray ray)
        {
            var result = new Intersections();
            foreach(var item in Elements)
            {
                result.AddRange(item.Intersect(ray));
            }
            return result;
        }
        public Colour ShadeHit(Comps comps)
        {
            return comps.Element.Material.Lighting(Light, comps.Point, comps.EyeV, comps.NormalV);
            // var shadowed = IsShadowed(comps.OverPoint);

            // var colour = comps.Element.Material.Lighting(Light, comps.OverPoint, comps.EyeV, comps.NormalV, shadowed);

            // return colour;
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
            return (h!= null && h.T < distance) ? true : false;
        }
    }
}