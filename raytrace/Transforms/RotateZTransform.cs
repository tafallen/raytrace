namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class RotateZTransform : BasicTransform
    {
        private RotateZTransform(Matrix matrix) => Matrix = matrix;
        public static RotateZTransform RotateZMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new RotateZTransform(new Matrix(new double[,]{
                {a,b,0,0},
                {c,a,0,0},
                {0,0,1,0},
                {0,0,0,1}
            }));
        }
        public override RotateZTransform Inverse()
        {
            return new RotateZTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"RotateZTransform: {Matrix}";
        }
    }
}