namespace RayTrace.Extensions
{
    using RayTrace.Models;

    public static class MatrixExtensions
    {
        public static double Determinant(this Matrix m)
        {
            var result = 0d;
            if(m.GetDimensions() != (2,2))
            {
                for(var i=0; i<m.GetDimensions().y;i++ )
                    result = result + m[0,i] * m.Cofactor(0,i);
                    // result = result + m.GetElement(0,i) * m.Cofactor(0,i);
            }
            else
            {
                var ad = m[0,0] * m[1,1]; 
                var bc = m[0,1] * m[1,0];
                result = ad - bc;
            }
            return result;
        }
        public static bool IsInvertable(this Matrix matrix)
        {
            return matrix.Determinant()!=0;
        }
        public static Matrix Inverse(this Matrix m)
        {
            var result = new Matrix(m.GetDimensions());
            var determinant = m.Determinant();

            for(var i=0; i<m.GetDimensions().x; i++)
                for(var j=0; j<m.GetDimensions().y; j++)
                    {
                        var value = m.Cofactor(j,i)/determinant;
                        result[i,j] = Math.Round(value,5);
                    }
            return result;
        }
        public static Matrix Transpose(this Matrix m)
        {
            var result = new Matrix((m.GetDimensions().y, m.GetDimensions().x));

            for(var i = 0; i<m.GetDimensions().x; i++)
                for(var j = 0; j<m.GetDimensions().y; j++)
                    result[i,j] = m[j,i];

            return result;
        }
        public static double Cofactor(this Matrix m, int x, int y)
        {
            var z = (x + y) % 2;
            var result = m.Minor(x,y);

            return  z !=0 ? -result : result;
        }
        public static double Minor(this Matrix m, int x, int y)
        {
            return m.Submatrix(x,y).Determinant();
        }
        public static Matrix Submatrix(this Matrix m, int row, int column)
        {
            var dimensions = m.GetDimensions();
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
                            result[l,k++] = m[i,j];
                    }
                    k=0;
                    l++;
                }
            }
            return result;
        }
    }
}