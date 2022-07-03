namespace RayTrace.Models
{
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    public class Sphere : Element
    {
        public Material Material{ get; set; }
        public RayTuple Origin{ get; set;}
        public double Radius {get; set;}
        public BasicTransform Transform {get; set;} 
        
        public Sphere()
        {
            Origin = RayTuple.Point(0,0,0);
            Radius = 1;
            Transform = BasicTransform.NullTransform;
            Material = new Material();
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
            var objectPoint = Transform.Matrix.Inverse() * point;
            var objectNormal = objectPoint - this.Origin;
            var worldNormal = (Transform.Matrix.Inverse()).Transpose() * objectNormal;
            return worldNormal.Normalise();
        }
    }
}