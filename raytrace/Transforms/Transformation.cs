namespace RayTrace.Transforms
{
    using RayTrace.Extensions;
    using RayTrace.Models;
    public class Transformation
    {
        public static Transformation NullTransform  => new Transformation();
        public static Transformation RotateX(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new Transformation(new Matrix(new double[,]{
                {1,0,0,0},
                {0,a,b,0},
                {0,c,a,0},
                {0,0,0,1}
            }));
        }
        public static Transformation RotateY(double rad)
        {
            var a = Math.Cos(rad);
            var b = Math.Sin(rad);
            var c = -Math.Sin(rad);

            return new Transformation(new Matrix(new double[,]{
                {a,0,b,0},
                {0,1,0,0},
                {c,0,a,0},
                {0,0,0,1}
            }));
        }
        public static Transformation RotateZ(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new Transformation(new Matrix(new double[,]{
                {a,b,0,0},
                {c,a,0,0},
                {0,0,1,0},
                {0,0,0,1}
            }));
        }
        public static Transformation Shearing(double xy, double xz, double yx, double yz, double zx, double zy )
        {
            return new Transformation(new Matrix(new double[,] {
                { 1,xy,xz, 0},
                {yx, 1,yz, 0},
                {zx,zy, 1, 0},
                { 0, 0, 0, 1}
            }));
        }
        public static Transformation Translation(double x, double y, double z)
        {
            var matrix = new Matrix(new double[,]{
                {1,0,0,x},
                {0,1,0,y},
                {0,0,1,z},
                {0,0,0,1}
            });
            return new Transformation(matrix);
        }
        public static ScalingTransform Scale(double x, double y, double z)
        {
            return new ScalingTransform( new Matrix(new double[,] {
                {x,0,0,0},
                {0,y,0,0},
                {0,0,z,0,},
                {0,0,0,1}}));
        }

        public Matrix Matrix {get; set;}
        public static Transformation operator *(Transformation a, Transformation b)
        {
            return new Transformation( a.Matrix * b.Matrix );
        }
        public Transformation Inverse()
        {
            return new Transformation(Matrix.Inverse());
        }
        public Point Transform(Point a)
        {
            return Matrix * a;
        }
        public Vector Transform(Vector a)
        {
            return Matrix * a;
        }
        public Ray Transform(Ray ray)
        {
            return new Ray(Transform(ray.Point),Transform(ray.Direction));
        }
        public override string ToString()
        {
            return $"Transform: {Matrix}";
        }
        protected Transformation() : this( Matrix.IdentityMatrix )
        { }
        public Transformation(Matrix matrix) => Matrix = matrix;
    }
}