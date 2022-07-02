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

        public override bool Equals(object? obj)
        {
            if( base.Equals(obj) == true)
                return true;

            if(obj == null) 
                return false;

            var b = obj as Material;
            if( b == null)
                return false;

            return( Colour.Equals(b.Colour) &&
                Ambient == b.Ambient &&
                Diffuse == b.Diffuse &&
                Specular == b.Specular &&
                Shininess == b.Shininess );
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
