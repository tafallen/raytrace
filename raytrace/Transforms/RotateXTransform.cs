namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class RotateXTransform : BasicTransform
    {
        private RotateXTransform(Matrix matrix) => Matrix = matrix;
        public static RotateXTransform RotateXMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new RotateXTransform(new Matrix(new double[,]{
                {1,0,0,0},
                {0,a,b,0},
                {0,c,a,0},
                {0,0,0,1}
            }));
        }
        public override RotateXTransform Inverse()
        {
            return new RotateXTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            var p = Transform(ray.Point);
            var d = Transform(ray.Direction);
            return new Ray(p,d);
        }
        public override string ToString()
        {
            return $"RotateXTransform: {Matrix}";
        }
    }
}