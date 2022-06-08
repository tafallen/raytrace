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
    }
}