namespace RayTrace.Transforms
{
    using RayTrace.Models;
    public class ScalingTransform : Transformation
    {
        public ScalingTransform(Matrix matrix) => Matrix = matrix;
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
    }
}