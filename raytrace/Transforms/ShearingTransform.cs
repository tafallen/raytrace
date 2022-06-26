namespace RayTrace.Transforms
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    public class ShearingTransform : BasicTransform
    {
        private ShearingTransform(Matrix matrix) => Matrix = matrix;
        public static ShearingTransform ShearingMatrix(double xy, double xz, double yx, double yz, double zx, double zy )
        {
            return new ShearingTransform(new Matrix(new double[,] {
                { 1,xy,xz, 0},
                {yx, 1,yz, 0},
                {zx,zy, 1, 0},
                { 0, 0, 0, 1}
            }));
        }
        public override ShearingTransform Inverse()
        {
            return new ShearingTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"ShearingTransform: {Matrix}";
        }
    }
}