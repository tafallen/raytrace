namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class RotateYTransform : BasicTransform
    {
        private RotateYTransform(Matrix matrix) => Matrix = matrix;
        public static RotateYTransform RotateYMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = Math.Sin(rad);
            var c = -Math.Sin(rad);

            return new RotateYTransform(new Matrix(new double[,]{
                {a,0,b,0},
                {0,1,0,0},
                {c,0,a,0},
                {0,0,0,1}
            }));
        }
        public override RotateYTransform Inverse()
        {
            return new RotateYTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"RotateYTransform: {Matrix}";
        }
    }
}