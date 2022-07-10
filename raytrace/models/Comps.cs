namespace RayTrace.Models
{
    public class Comps
    {
        public Element Element {get;set;}
        public Point Point {get; set;}
        public Point OverPoint {get; set;}
        public Vector EyeV {get; set;}
        public Vector NormalV {get; set;}
        public double Time {get; set;}
        public bool Inside{get;set;}

        public Comps(double t, Element element, Point point, Point overPoint, Vector eyev, Vector normalv, bool inside)
        {
            Time = t;
            Element = element;
            Point = point;
            EyeV = eyev;
            NormalV = normalv;
            Inside = inside;
            OverPoint = overPoint;
        }
    }
}