namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class ViewTransform : Transformation
    {
        private ViewTransform(Matrix matrix) => Matrix = matrix;
        public static ViewTransform ViewTransformMatrix(Point from, Point to, Vector up)
        {
            var forward = (to - from).Normalise();
            var upn = up.Normalise();
            var left = forward.CrossProduct(upn);
            var trueUp = left.CrossProduct(forward);

            var orientation = new Matrix(new double[,]
            {
                {left.X,     left.Y,     left.Z,     0},
                {trueUp.X,   trueUp.Y,   trueUp.Z,   0},
                {-forward.X, -forward.Y, -forward.Z, 0},
                {0,          0,          0,          1}
            });

            var result = orientation * Transformation.Translation(-from.X, -from.Y, -from.Z).Matrix;
            return new ViewTransform(result);
        }
    }
}