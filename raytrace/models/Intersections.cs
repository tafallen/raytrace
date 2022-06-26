namespace RayTrace.Models
{
    using System.Linq;

    public class Intersections : List<Intersection>
    {
        public static Intersections List = new Intersections();

        public static Intersection? Hit()
        {
            var positives = Intersections.List.Where(item => item.T >= 0);

            return positives.Min<Intersection>();
        }
    }
}