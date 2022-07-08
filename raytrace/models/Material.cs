namespace RayTrace.Models
{
    using RayTrace.Extensions;
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

        public override bool Equals(object? obj)
        {
            if( base.Equals(obj) == true)
                return true;

            if(obj == null) 
                return false;

            var b = obj as Material;
            return b == null ? false : Equals(b);
        }

        public bool Equals(Material b)
        {
            return( Colour.Equals(b.Colour) &&
                Ambient == b.Ambient &&
                Diffuse == b.Diffuse &&
                Specular == b.Specular &&
                Shininess == b.Shininess );
        }

        public Colour Lighting(Light light, Point point, Vector eyev, Vector normalv)
        {
            var effectiveColour = Colour * light.Intensity;
            var lightv = (light.Position - point).Normalise();
            var ambient = effectiveColour * Ambient;
            var lightDotNormal = lightv.DotProduct(normalv);
            var diffuse = new Colour(0,0,0);
            var specular = new Colour(0,0,0);

            if( lightDotNormal > 0)
            {
                diffuse = effectiveColour * Diffuse * lightDotNormal;
                var reflectv = (lightv * -1).Reflect(eyev); 
                var reflectDotEye = reflectv.DotProduct(eyev);

                if (reflectDotEye > 0)
                {
                    var factor = Math.Pow(reflectDotEye, Shininess);
                    specular = light.Intensity * Specular * factor;
                }
            }
            return ambient + diffuse + specular;
        }

        public override int GetHashCode()
        {
            return Colour.GetHashCode() + 
                   Ambient.GetHashCode() +  
                   Diffuse.GetHashCode() +  
                   Specular.GetHashCode() +  
                   Shininess.GetHashCode();  
        }

        public override string ToString()
        {
            return $"Material: {Colour} Amb: {Ambient}, Dif: {Diffuse}, Spec: {Specular}, Shi: {Shininess}";
        }
    }
}
