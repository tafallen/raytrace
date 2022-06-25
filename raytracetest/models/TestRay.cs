namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestRay
    {
        [TestMethod]
        public void CreateSucceeds()
        {
            var point = RayTuple.Point(1,2,3);
            var direction = RayTuple.Vector(2,3,4);
            var ray = new Ray(point,direction);

            Assert.IsNotNull(ray);
            Assert.AreEqual(direction, ray.Direction);
            Assert.AreEqual(point, ray.Point);
        }
        [TestMethod]
        public void TestPostionSucceeds()
        {
            var point = RayTuple.Point(2,3,4);
            var direction = RayTuple.Vector(1,0,0);
            var ray = new Ray(point,direction);

            var p1 = ray.Position(0);
            RayTuple.Point(2,3,4).Assert(p1);
            var p2 = ray.Position(1);
            RayTuple.Point(3,3,4).Assert(p2);
            var p3 = ray.Position(-1);
            RayTuple.Point(1,3,4).Assert(p3);
            var p4 = ray.Position(2.5);
            RayTuple.Point(4.5,3,4).Assert(p4);
        }
        [TestMethod]
        public void TestRaySphereIntersectSucceeds()
        {
            var ray = new Ray(RayTuple.Point(0,0,-5),RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var xs = sphere.Intersect(ray);

            Assert.IsNotNull(xs);
            Assert.AreEqual(2, xs.Length);
            Assert.AreEqual(4.0, xs[0]);
            Assert.AreEqual(6.0, xs[1]);
        }
        [TestMethod]
        public void TestRaySphereTangentSucceeds()
        {
            var ray = new Ray(RayTuple.Point(0,1,-5),RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var xs = sphere.Intersect(ray);

            Assert.IsNotNull(xs);
            Assert.AreEqual(2, xs.Length);
            Assert.AreEqual(5.0, xs[0]);
            Assert.AreEqual(5.0, xs[1]);
        }
        [TestMethod]
        public void TestRaySphereMissSucceeds()
        {
            var ray = new Ray(RayTuple.Point(0,2,-5),RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var xs = sphere.Intersect(ray);

            Assert.IsNotNull(xs);
            Assert.AreEqual(0, xs.Length);
        }
        [TestMethod]
        public void TestRaySphereRayOriginCentreSucceeds()
        {
            var ray = new Ray(RayTuple.Point(0,0,0),RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var xs = sphere.Intersect(ray);

            Assert.IsNotNull(xs);
            Assert.AreEqual(2, xs.Length);
            Assert.AreEqual(-1.0, xs[0]);
            Assert.AreEqual(1.0, xs[1]);
        }        
    }
}