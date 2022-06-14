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
        public static RayTuple operator *(Matrix a, RayTuple b)
        {
            var result = new double[4];
            for(var j = 0; j<4; j++)
            {
                result[j] = a.GetElement(j,0) * b.X +
                            a.GetElement(j,1) * b.Y +
                            a.GetElement(j,2) * b.Z + 
                            a.GetElement(j,3) * (int)b.Type;
            }

            return new RayTuple(result[0],result[1],result[2],b.Type);
        }
        public static Matrix ScaleMatrix(double x, double y, double z)
        {
            return new Matrix(new double[,] {
                {x,0,0,0},
                {0,y,0,0},
                {0,0,z,0,},
                {0,0,0,1}});
        }
        public static Matrix RotateXMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new Matrix(new double[,]{
                {1,0,0,0},
                {0,a,b,0},
                {0,c,a,0},
                {0,0,0,1}
            });
        }
        public static Matrix RotateYMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = Math.Sin(rad);
            var c = -Math.Sin(rad);

            return new Matrix(new double[,]{
                {a,0,b,0},
                {0,1,0,0},
                {c,0,a,0},
                {0,0,0,1}
            });
        }
        public static Matrix RotateZMatrix(double rad)
        {
            var a = Math.Cos(rad);
            var b = -Math.Sin(rad);
            var c = Math.Sin(rad);

            return new Matrix(new double[,]{
                {a,b,0,0},
                {c,a,0,0},
                {0,0,1,0},
                {0,0,0,1}
            });
        }
        public static Matrix ShearingMatrix(double xy, double xz, double yx, double yz, double zx, double zy )
        {
            return new Matrix(new double[,] {
                { 1,xy,xz, 0},
                {yx, 1,yz, 0},
                {zx,zy, 1, 0},
                { 0, 0, 0, 1}
            });
        }
        public Matrix Transpose()
        {
            var result = new Matrix((GetDimensions().y,GetDimensions().x));

            for(var i = 0; i<GetDimensions().x; i++)
                for(var j = 0; j<GetDimensions().y; j++)
                    result.SetElement(i,j,this.GetElement(j,i));

            return result;
        }
        public double Determinant()
        {
            var result = 0d;
            if(GetDimensions() != (2,2))
            {
                for(var i=0; i<matrix.GetLength(1);i++ )
                    result = result + matrix[0,i] * Cofactor(0,i);
            }
            else
            {
                var ad = matrix[0,0] * matrix[1,1]; 
                var bc = matrix[0,1] * matrix[1,0];
                result = ad - bc;
            }
            return result;
        }
        public Matrix Submatrix(int row, int column)
        {
            var dimensions = GetDimensions();
            var result = new Matrix((dimensions.x-1,dimensions.y-1));
            var k=0;
            var l=0;
            for(var i=0;i<dimensions.x;i++)
            {
                if(i!=row)
                {
                    for(var j=0;j<dimensions.y;j++)
                    {
                        if(j!=column)
                        {
                            result.SetElement(l,k++,matrix[i,j]);
                        }
                    }
                    k=0;
                    l++;
                }
            }
            return result;
        }
        public double Minor(int x, int y)
        {
            return Submatrix(x,y).Determinant();
        }
        public double Cofactor(int x, int y)
        {
            var z = (x + y) % 2;
            var result = Minor(x,y);

            return  z !=0 ? -result : result;
        }
        public bool IsInvertable()
        {
            return Determinant()!=0;
        }
        public Matrix Inverse()
        {
            var result = new Matrix(GetDimensions());
            var determinant = Determinant();

            for(var i=0; i<matrix.GetLength(0); i++)
                for(var j=0; j<matrix.GetLength(1); j++)
                    {
                        var value = Cofactor(j,i)/determinant;
                        result.SetElement(i,j,Math.Round(value,5));
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