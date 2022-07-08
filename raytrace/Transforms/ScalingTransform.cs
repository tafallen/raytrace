namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;

    public class ScalingTransform : BasicTransform
    {
        private ScalingTransform(Matrix matrix) => Matrix = matrix;
        public static ScalingTransform ScaleMatrix(double x, double y, double z)
        {
            return new ScalingTransform( new Matrix(new double[,] {
                {x,0,0,0},
                {0,y,0,0},
                {0,0,z,0,},
                {0,0,0,1}}));
        }
        public override ScalingTransform Inverse()
        {
            return new ScalingTransform(Matrix.Inverse());
        }
        public override Ray Transform(Ray ray)
        {
            var p = Transform(ray.Point);
            var d = Transform(ray.Direction);
            return new Ray(p,d);
        }
        public new Point Transform(Point a)
        {
            return new Point(
                a.X * Matrix[0,0], 
                a.Y * Matrix[1,1], 
                a.Z * Matrix[2,2]);
        }
        public new Vector Transform(Vector a)
        {
            return new Vector(
                a.X * Matrix[0,0], 
                a.Y * Matrix[1,1], 
                a.Z * Matrix[2,2]);
        }
        public override string ToString()
        {
            return $"ScalingTransform: {Matrix}";
        }
    }
}