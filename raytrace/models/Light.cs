namespace RayTrace.Models
{
    public class Light
    {
        public Colour Intensity { get; set; }
        public RayTuple Position { get; set; }

        public Light()
        {
            Intensity = new Colour(0,0,0);
            Position = RayTuple.Point(0,0,0);
        }
    }
}
