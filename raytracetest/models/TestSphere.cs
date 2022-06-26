namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    [TestClass]
    public class TestSphere
    {
        [TestMethod]
        public void CreateSucceeds()
        {
            var sphere = new Sphere();
            Assert.IsNotNull(sphere);
        }
        [TestMethod]
        public void SetTransformationSucceeds()
        {
            var sphere = new Sphere();
            var matrix = new Matrix(new double[,] {{2,3,4}});

            sphere.Transform = matrix;

            Assert.AreEqual(matrix, sphere.Transform);
        }
    }
}