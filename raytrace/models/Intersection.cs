namespace RayTrace.Models
{
    public class Intersection
    {
        public double T {get; set;}
        public Element Element {get; set;}
        public Intersection(double t, Element element)
        {   
            T = t;
            Element = element;
        }
    }
}