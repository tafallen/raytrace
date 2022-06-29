namespace RayTrace.Models
{
    using RayTrace.Extensions;
    using RayTrace.Transforms;

    public class Sphere : Element
    {
        public RayTuple Origin{ get; set;}
        public double Radius {get; set;}
        public BasicTransform Transform {get; set;} 
        
        public Sphere()
        {
            Origin = RayTuple.Point(0,0,0);
            Radius = 1;
            Transform = BasicTransform.NullTransform;
        }
        public Sphere(RayTuple origin) : this()
        {
            Origin = origin;
        }
        public override string ToString()
        {
            return $"Sphere - Radius: {Radius}, Origin: {Origin}, Transform: {Transform}";
        }
        public RayTuple NormalAt(RayTuple point)
        {
            var result = point - this.Origin;
            return result.Normalise();
        }
    }
}