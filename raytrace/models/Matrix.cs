namespace RayTrace.Models
{
    using System.Text;

    public class Matrix
    {
        public static Matrix IdentityMatrix = new Matrix(new double[4,4] 
        {
            {1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1}
        });

        private double[,] matrix;

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public Matrix((int x,int y)dimensions)
        {
            matrix = new double[dimensions.x,dimensions.y];
            for(var i = 0; i<dimensions.x; i++)
                for(var j = 0; j<dimensions.y; j++)
                    matrix[i,j] = 0;
        }
        public double this[int x, int y]
        {
            get => matrix[x,y];
            set => matrix[x,y] = value;
        }
        public (int x,int y) GetDimensions()
        {
            return (matrix.GetLength(0), matrix.GetLength(1));
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if( a.GetDimensions() != b.GetDimensions())
                throw new ArgumentException("operator *() - The two matricies did not have the same dimensions");
            var x = a.GetDimensions().x;
            var y = a.GetDimensions().y;

            var result = new Matrix(a.GetDimensions());
            for(var i = 0; i<a.GetDimensions().x; i++)
                for(var j = 0; j<a.GetDimensions().y; j++)
                {
                    var z = a[i,0] * b[0,j] +
                            a[i,1] * b[1,j] +
                            a[i,2] * b[2,j] + 
                            a[i,3] * b[3,j];
                    result[i, j] = z;
                }
            return result;
        }
        public static double[] operator *(Matrix a, double[] b)
        {
            var result = new double[b.Length];
            for(var j = 0; j<b.Length; j++)
            {
                result[j] = a[j,0] * b[0] +
                            a[j,1] * b[1] +
                            a[j,2] * b[2] + 
                            a[j,3] * b[3];
            }
            return result;
        }
        public static Point operator *(Matrix a, Point b)
        {
            var result = new double[4];
            for(var j = 0; j<4; j++)
            {
                result[j] = a[j,0] * b.X +
                            a[j,1] * b.Y +
                            a[j,2] * b.Z + 
                            a[j,3] * 1;
            }
            return new Point(result[0],result[1],result[2]);
        }
        public static Vector operator *(Matrix a, Vector b)
        {
            var result = new double[4];
            for(var j = 0; j<4; j++)
            {
                result[j] = a[j,0] * b.X +
                            a[j,1] * b.Y +
                            a[j,2] * b.Z + 
                            a[j,3] * 0;
            }
            return new Vector(result[0],result[1],result[2]);
        }
        
        public override bool Equals(object? obj)
        {
            var other = obj as Matrix;
            if( obj == null || other == null )
                throw new ArgumentException("Equals() - other is null");
            var x = GetDimensions().x;
            var y = GetDimensions().y;

            if(x != other.GetDimensions().x ||
               y != other.GetDimensions().y)
                return false;

            for(var i = 0; i < x; i++)
                for(var j = 0; j < y; j++)
                    if( this[i,j] != other[i,j])
                        return false;

            return true;
        }
        public override int GetHashCode()
        {
            return matrix.GetHashCode();
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            var x = GetDimensions().x;
            var y = GetDimensions().y;

            for(var i = 0; i<x; i++)
            {
                builder.Append("(");
                for(var j = 0; j<y; j++)
                {
                    builder.Append($"{matrix[i,j]} ");
                }
                builder.AppendLine(")");
            }
            return builder.ToString();
        }
    }
}