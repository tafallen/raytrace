namespace RayTrace.Models
{
    using RayTrace.Extensions;

    public class Sphere : Element
    {
        public RayTuple Origin{ get; set;}
        public double Radius {get; set;}
        public Transform Transform {get; set;} 
        
        public Sphere()
        {
            Origin = RayTuple.Point(0,0,0);
            Radius = 1;
            Transform = Models.Transform.NullTransform;
        }
        public Sphere(RayTuple origin) : this()
        {
            Origin = origin;
        }
        public override string ToString()
        {
            return $"Sphere - Radius: {Radius}, Origin: {Origin}, Transform: {Transform}";
        }
    }
}