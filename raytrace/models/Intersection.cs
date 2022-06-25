namespace RayTrace.Models
{
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
            return T.CompareTo(other.T);
        }

        public override string ToString()
        {
            return $"Intersection( T: {T}, Element: {Element} )";
        }
    }
}