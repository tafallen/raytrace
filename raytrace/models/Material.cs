namespace RayTrace.Models
{
    public class Material
    {
        public Colour Colour { get; set; }
        public double Ambient { get; set; }
        public double Diffuse { get; set; }
        public double Specular { get; set; }
        public double Shininess { get; set; }

        public Material()
        {
            Colour = new Colour(1,1,1);
            Ambient = 0.1;
            Diffuse = 0.9;
            Specular = 0.9;
            Shininess = 200.0;
        }
    }
}
