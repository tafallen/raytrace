namespace RayTrace.Models
{
    using System.Linq;

    public class Intersections : List<Intersection>
    {
        public Intersection? Hit()
        {
            var positives = this.Where(item => item.T >= 0);

            return positives.Min<Intersection>();
        }
    }
}