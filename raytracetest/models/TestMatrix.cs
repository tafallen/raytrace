namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void CreateSucceeds()
        {
            var matrix = new Matrix(new double[4,4] {{1,2,3,4},{5.5,6.5,7.5,8.5},{9,10,11,12},{13.5,14.5,15.5,16.5}});
            Assert.IsNotNull(matrix);
            Assert.IsInstanceOfType(matrix, typeof(Matrix));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"GetElement() - x and y must be in the bounds of the matrix")]
        public void GetElementXZeroFails()
        {
            var matrix = new Matrix(new double[4,4] );
            matrix.GetElement(-1,1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"GetElement() - x and y must be in the bounds of the matrix")]
        public void GetElementXGreaterThanLengthFails()
        {
            var matrix = new Matrix(new double[4,4] );
            matrix.GetElement(7,1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"GetElement() - x and y must be in the bounds of the matrix")]
        public void GetElementYZeroFails()
        {
            var matrix = new Matrix(new double[4,4] );
            matrix.GetElement(1,-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"GetElement() - x and y must be in the bounds of the matrix")]
        public void GetElementYGreaterThanLengthFails()
        {
            var matrix = new Matrix(new double[4,4] );
            matrix.GetElement(1,7);
        }
                
        [TestMethod]
        public void GetElementSucceeds()
        {
            var matrix = new Matrix(new double[4,4] {{1,2,3,4},{5.5,6.5,7.5,8.5},{9,10,11,12},{13.5,14.5,15.5,16.5}});
            Assert.AreEqual(4,matrix.GetElement(0,3));
        }
        [TestMethod]
        public void EqualsFails()
        {
            var matrix1 = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});
            var matrix2 = new Matrix(new double[4,4] {{2,3,4,5},{6,7,8,9},{8,7,6,5},{4,3,2,1}});

            Assert.IsFalse(matrix1.Equals(matrix2));
            Assert.AreNotEqual(matrix1,matrix2);
        }
        [TestMethod]
        public void EqualsSucceeds()
        {
            var matrix1 = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});
            var matrix2 = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});

            Assert.IsTrue(matrix1.Equals(matrix2));
            Assert.AreEqual(matrix1,matrix2);
        }
        [TestMethod]
        public void MultiplicationSucceeds()
        {
            var matrix1 = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});
            var matrix2 = new Matrix(new double[4,4] {{-2,1,2,3},{3,2,1,-1},{4,3,6,5},{1,2,7,8}});

            var expectedResult = new Matrix(new double[4,4] {{20,22,50,48},{44,54,114,108},{40,58,110,102},{16,26,46,42}});
            var actualResult = matrix1 * matrix2;

            Assert.IsTrue(expectedResult.Equals(actualResult));
            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"operator *() - The two matricies did not have the same dimensions")]
        public void MultiplicationFails()
        {
            var matrix1 = new Matrix(new double[3,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6}});
            var matrix2 = new Matrix(new double[4,4] {{-2,1,2,3},{3,2,1,-1},{4,3,6,5},{1,2,7,8}});

            var result = matrix1 * matrix2;
        }
        [TestMethod]
        public void TupleMultiplicationSucceeds()
        {
            var matrix = new Matrix(new double[4,4] {{1,2,3,4},{2,4,4,2},{8,6,4,1},{0,0,0,1}});
            double[] tuple = {1,2,3,1};

            double[] expectedResult = {18,24,33,1};
            var actualResult = matrix * tuple;

            for(var i = 0; i < expectedResult.Length ; i++)
                Assert.AreEqual(expectedResult[i],actualResult[i]);
        }
        [TestMethod]
        public void IdentityMatrixMultiplicationSucceeds()
        {
            var matrix1 = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});
            var matrix2 = new Matrix(new double[4,4] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1}});

            var expectedResult = new Matrix(new double[4,4] {{1,2,3,4},{5,6,7,8},{9,8,7,6},{5,4,3,2}});
            var actualResult = matrix1 * matrix2;

            Assert.IsTrue(expectedResult.Equals(actualResult));
            Assert.AreEqual(expectedResult,actualResult);

            actualResult = matrix1 * Matrix.IdentityMatrix;

            Assert.IsTrue(expectedResult.Equals(actualResult));
            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        public void IdentityMatrixIntegrityCheckSucceeds()
        {
            var idm = new Matrix(new double[4,4] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1}});

            Assert.IsTrue(idm.Equals(Matrix.IdentityMatrix));
            Assert.AreEqual(idm,Matrix.IdentityMatrix);
        }
        [TestMethod]
        public void TransposeSucceeds()
        {
            var matrix1 = new Matrix(new double[4,4] {{0,9,3,0},{9,8,0,8},{1,8,5,3},{0,0,5,8}});

            var expectedResult = new Matrix(new double[4,4] {{0,9,1,0},{9,8,8,0},{3,0,5,5},{0,8,3,8}});
            var actualResult = matrix1.Transpose();

            Assert.IsTrue(expectedResult.Equals(actualResult));
            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        public void TransposeIdentityMatrixSucceeds()
        {
            var expectedResult = new Matrix(new double[4,4] {{1,0,0,0},{0,1,0,0},{0,0,1,0},{0,0,0,1}});
            var actualResult = Matrix.IdentityMatrix.Transpose();

            Assert.IsTrue(expectedResult.Equals(actualResult));
            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        public void Determinant2x2Succeeds()
        {
            var matrix = new Matrix(new double[,] {{1,5},{-3,2}});
            var actualResult = matrix.Determinant();
            Assert.AreEqual(17,actualResult);
        }
        [TestMethod]
        public void SubmatrixOf3x3Succeeds()
        {
            var matrix = new Matrix(new double[,] {{1,5,0},{-3,2,7},{0,6,-3}});
            var original = new Matrix(new double[,] {{1,5,0},{-3,2,7},{0,6,-3}});

            var expectedResult = new Matrix(new double[,]{{-3,2},{0,6}});
            Assert.AreEqual(expectedResult, matrix.Submatrix(0,2));
            Assert.AreEqual(original,matrix);
        }
        [TestMethod]
        public void SubmatrixOf4x4Succeeds()
        {
            var matrix = new Matrix(new double[,] {{-6,1,1,6},{-8,5,8,6},{-1,0,8,2},{-7,1,-1,1}});

            var expectedResult = new Matrix(new double[,]{{-6,1,6},{-8,8,6},{-7,-1,1}});
            Assert.AreEqual(expectedResult, matrix.Submatrix(2,1));
        }
        [TestMethod]
        public void MinorSucceeds()
        {
            var matrix = new Matrix(new double[,]{{3,5,0},{2,-1,-7},{6,-1,5}});

            var expectedResult = 25d;
            var actualResult = matrix.Minor(1,0);

            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        public void CofactorSucceed()
        {
            var matrix = new Matrix(new double[,] {{3,5,0},{2,-1,-7},{6,-1,5}});

            Assert.AreEqual(-12, matrix.Minor(0,0));
            Assert.AreEqual(-12, matrix.Cofactor(0,0));
            Assert.AreEqual(25, matrix.Minor(1,0));
            Assert.AreEqual(-25, matrix.Cofactor(1,0));
        }
        [TestMethod]
        public void Determinant3x3Succeeds()
        {
            var matrix = new Matrix(new double[,]{{1,2,6},{-5,8,-4},{2,6,4}});

            Assert.AreEqual( 56, matrix.Cofactor(0,0));
            Assert.AreEqual( 12, matrix.Cofactor(0,1));
            Assert.AreEqual(-46, matrix.Cofactor(0,2));
            Assert.AreEqual(-196, matrix.Determinant());
        }
        [TestMethod]
        public void Determinant4x4Succeeds()
        {
            var matrix = new Matrix(new double[,] {{-2,-8,3,5},{-3,1,7,3},{1,2,-9,6},{-6,7,7,-9}});

            Assert.AreEqual(690, matrix.Cofactor(0,0));
            Assert.AreEqual(447, matrix.Cofactor(0,1));
            Assert.AreEqual(210, matrix.Cofactor(0,2));
            Assert.AreEqual(51, matrix.Cofactor(0,3));
            Assert.AreEqual(-4071, matrix.Determinant());            
        }
    }
}