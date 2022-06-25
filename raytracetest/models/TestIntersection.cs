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
        [TestMethod]
        public void TestHitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(1, sphere);
            var i2 = new Intersection(2, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.Hit();
            Assert.AreEqual(i1, hit);
        }
        [TestMethod]
        public void TestFirstPositiveHitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(3, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.Hit();
            Assert.AreEqual(i2, hit);
        }
        [TestMethod]
        public void TestEmptyIfNoPosHitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(-3, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.Hit();
            Assert.IsNull(hit);
        }
        public void TestLowestHitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(5, sphere);
            var i2 = new Intersection(7, sphere);
            var i3 = new Intersection(-3, sphere);
            var i4 = new Intersection(2, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            Intersections.List.Add(i3);
            Intersections.List.Add(i4);
            
            var hit = Intersections.Hit();
            Assert.AreEqual(i4, hit);
        }
        [TestInitialize]
        public void Setup()
        {
            Intersections.List.Clear();
        }
    }
}
