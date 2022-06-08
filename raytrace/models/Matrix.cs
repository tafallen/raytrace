using System.Text;

namespace RayTrace.Models
{
    public class Matrix
    {
        public static Matrix IdentityMatrix = new Matrix(new double[4,4] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1}});

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
        public double GetElement(int x, int y)
        {
            if (x > matrix.GetLength(0) || 
                y > matrix.GetLength(1) || 
                x < 0 || 
                y < 0)
                throw new ArgumentException("GetElement() - x and y must be in the bounds of the matrix");

            return matrix[x,y];
        }
        public void SetElement(int x, int y, double value)
        {
            if (x > matrix.GetLength(0) || 
                y > matrix.GetLength(1) || 
                x < 0 || 
                y < 0)
                throw new ArgumentException("GetElement() - x and y must be in the bounds of the matrix");
            matrix[x,y] = value;
        }
        public (int x,int y) GetDimensions()
        {
            return (matrix.GetLength(0), matrix.GetLength(1));
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if( a.GetDimensions().x != b.GetDimensions().x ||
                a.GetDimensions().y != b.GetDimensions().y)
                throw new ArgumentException(" operator *() - The two matricies did not have the same dimensions");

            var result = new Matrix(a.GetDimensions());
            for(var i = 0; i<a.GetDimensions().x; i++)
                for(var j = 0; j<a.GetDimensions().y; j++)
                {
                    var x = a.GetElement(i,0) * b.GetElement(0,j) +
                            a.GetElement(i,1) * b.GetElement(1,j) +
                            a.GetElement(i,2) * b.GetElement(2,j) + 
                            a.GetElement(i,3) * b.GetElement(3,j);
                    result.SetElement(i, j, x);
                }
            return result;
        }
        public static double[] operator *(Matrix a, double[] b)
        {
            var result = new double[b.Length];
            for(var j = 0; j<b.Length; j++)
            {
                result[j] = a.GetElement(j,0) * b[0] +
                            a.GetElement(j,1) * b[1] +
                            a.GetElement(j,2) * b[2] + 
                            a.GetElement(j,3) * b[3];
            }

            return result;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Matrix;
            if( obj == null || other == null )
                throw new ArgumentException("Equals() - other is null");

            if( GetDimensions().x != other.GetDimensions().x ||
                GetDimensions().y != other.GetDimensions().y)
                return false;

            for(var i = 0; i < GetDimensions().x; i++)
                for(var j = 0; j < GetDimensions().y; j++)
                    if( this.GetElement(i,j) != other.GetElement(i,j))
                        return false;

            return true;
        }
        public override int GetHashCode()
        {
            return matrix.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for(var i = 0; i<GetDimensions().x; i++)
            {
                builder.Append("(");
                for(var j = 0; j<GetDimensions().y; j++)
                {
                    builder.Append($"{matrix[i,j]} ");
                }
                builder.AppendLine(")");
            }
            return builder.ToString();
        }
    }
}