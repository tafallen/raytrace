namespace RayTrace.Models
{
    public class Sphere : Element
    {
        public RayTuple Origin{ get; set;}
        public double Radius {get; set;}
        public Matrix Transform {get; set;} 
        
        public Sphere()
        {
            Origin = RayTuple.Point(0,0,0);
            Radius = 1;
            Transform = Matrix.IdentityMatrix;
        }
    }
}