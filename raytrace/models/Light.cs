namespace RayTrace.Models
{
    public class Light
    {
        public Colour Intensity { get; set; }
        public Point Position { get; set; }

        public Light()
        {
            Intensity = new Colour(0,0,0);
            Position = new Point(0,0,0);
        }
    }
}
