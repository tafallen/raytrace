namespace RayTrace.Transforms
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    public class TranslationTransform : BasicTransform
    {
        private TranslationTransform(Matrix matrix) => Matrix = matrix;
        public static TranslationTransform TranslationMatrix(double x, double y, double z)
        {
            var matrix = new Matrix(new double[,]{
                {1,0,0,x},
                {0,1,0,y},
                {0,0,1,z},
                {0,0,0,1}
            });
            return new TranslationTransform(matrix);
        }
        public override TranslationTransform Inverse()
        {
            return new TranslationTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            var p = Transform(ray.Point);
            return new Ray(p, ray.Direction);
        }
        public override string ToString()
        {
            return $"TranslationTransform: {Matrix}";
        }
    }
}