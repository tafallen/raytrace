namespace RayTrace.Models
{
    using RayTrace.Extensions;
    public class Transform
    {
        public static Transform NullTransform  => new Transform();
        public Matrix Matrix {get; protected set;}
        protected Transform()
        {
            Matrix = Matrix.IdentityMatrix;
        }
    }
    public class ScalingTransform : Transform
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
        public ScalingTransform Inverse()
        {
            return new ScalingTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"ScalingTransform: {Matrix}";
        }
    }
    public class TranslationTransform : Transform
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
        public TranslationTransform Inverse()
        {
            return new TranslationTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"TranslationTransform: {Matrix}";
        }
    }
    public class RotateXTransform : Transform
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
        public RotateXTransform Inverse()
        {
            return new RotateXTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"RotateXTransform: {Matrix}";
        }
    }
    public class RotateYTransform : Transform
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
        public RotateYTransform Inverse()
        {
            return new RotateYTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"RotateYTransform: {Matrix}";
        }
    }
    public class RotateZTransform : Transform
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
        public RotateZTransform Inverse()
        {
            return new RotateZTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"RotateZTransform: {Matrix}";
        }
    }
    public class ShearingTransform : Transform
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
        public ShearingTransform Inverse()
        {
            return new ShearingTransform(Matrix.Inverse());
        }
        public override string ToString()
        {
            return $"ShearingTransform: {Matrix}";
        }
    }
}