namespace RayTrace.Models
{
    using RayTrace.Extensions;
    public class Intersection : IComparable<Intersection>
    {
        public double T {get; set;}
        public Element Element {get; set;}
        public Intersection(double t, Element element)
        {   
            T = t;
            Element = element;
        }

        public int CompareTo(Intersection? other)
        {
            if( other == null)
                return -1;
            return T.CompareTo(other.T);
        }
        public override string ToString()
        {
            return $"Intersection( T: {T}, Element: {Element} )";
        }
        public Comps PrepareComputations(Ray r)
        {
            var point = r.Position(T);
            var eyev = !r.Direction;
            var normalv = ((Sphere)Element).NormalAt(point);
            var inside = false;

            if( normalv.DotProduct(eyev) < 0)
            {
                inside = true;
                normalv = !normalv;
            }
            var overPoint = point * normalv * DoubleExtensions.EPSILON;

            return new Comps(T, Element, point, overPoint , eyev, normalv, inside);
        }
    }
}