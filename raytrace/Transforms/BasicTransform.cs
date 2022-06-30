namespace RayTrace.Transforms
{
    using RayTrace.Models;
    public abstract class BasicTransform
    {
        public static BasicTransform NullTransform  => TranslationTransform.TranslationMatrix(0d,0d,0d);
        public Matrix Matrix {get; set;}
        protected BasicTransform()
        {
            Matrix = Matrix.IdentityMatrix;
        }
        public abstract BasicTransform Inverse();

        public static BasicTransform operator *(BasicTransform a, BasicTransform b)
        {
            var result = new CompoundTransform();
            result.Matrix = a.Matrix * b.Matrix;
            return result;
        }
        public abstract Ray Transform(Ray ray);
        public RayTuple Transform(RayTuple a)
        {
            return Matrix * a;
        }
    }
}