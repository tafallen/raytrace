namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class CompoundTransform : BasicTransform
    {
        public override CompoundTransform Inverse()
        {
            return new CompoundTransform()
            {
                Matrix = Matrix.Inverse()
            };
        }

        public override Ray Transform(Ray ray)
        {
            var p = Transform(ray.Point);
            var d = Transform(ray.Direction);
            return new Ray(p,d);
        }
    }
}