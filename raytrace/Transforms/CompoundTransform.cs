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
            throw new NotImplementedException();
        }
    }
}