namespace RayTrace.Models
{
    public class Comps
    {
        public Element Element {get;set;}
        public RayTuple Point {get; set;}
        public RayTuple EyeV {get; set;}
        public RayTuple NormalV {get; set;}
        public double T {get; set;}
        public bool Inside{get;set;}

        public Comps(double t, Element element, RayTuple point, RayTuple eyev, RayTuple normalv, bool inside)
        {
            T = t;
            Element = element;
            Point = point;
            EyeV = eyev;
            NormalV = normalv;
            Inside = inside;
        }
    }
}