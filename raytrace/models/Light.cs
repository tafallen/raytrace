namespace RayTrace.Models
{
    public class Light
    {
        public Colour Intensity { get; set; }
        public Point Position { get; set; }

        public Light() : this(new Point(0,0,0), new Colour(0,0,0))
        {
        }

        public Light(Point position, Colour intensity)
        {
            Position = position;
            Intensity = intensity;
        }
    }
}
