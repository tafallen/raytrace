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
        public void TestPostion()
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
    }
}