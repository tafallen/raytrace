namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestIntersection
    {
        [TestMethod]
        public void CreateSucceeds()
        {
            var sphere = new Sphere();
            var intersection = new Intersection(3.5, sphere);

            Assert.IsNotNull(intersection);
            Assert.AreEqual(3.5, intersection.T);
            Assert.AreEqual(sphere, intersection.Element);
        }
    }
}
