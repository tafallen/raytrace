namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTraceTest.Assertors;

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
        public void HitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(1, sphere);
            var i2 = new Intersection(2, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.List.Hit();
            Assert.AreEqual(i1, hit);
        }
        [TestMethod]
        public void FirstPositiveHitReturnedSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(3, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.List.Hit();
            Assert.AreEqual(i2, hit);
        }
        [TestMethod]
        public void EmptyIfNoPosHitSucceeds()
        {
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(-3, sphere);
            Intersections.List.Add(i1);
            Intersections.List.Add(i2);
            
            var hit = Intersections.List.Hit();
            Assert.IsNull(hit);
        }
        [TestMethod]
        public void LowestHitReturnedSucceeds()
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
            
            var hit = Intersections.List.Hit();
            Assert.AreEqual(i4, hit);
        }
        [TestMethod]
        public void PrecomputeIntersectionState()
        {
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(4, sphere);

            var comps = i.PrepareComputations(ray);
            Assert.AreEqual( i.T, comps.T);
            Assert.AreEqual( i.Element, comps.Element);
            RayTuple.Vector(0,0,-1).Assert(comps.EyeV);
            RayTuple.Vector(0,0,-1).Assert(comps.NormalV);
            RayTuple.Point(0,0,-1).Assert(comps.Point);
        }
        [TestMethod]
        public void HitWhenIntersectionOccursOnOutside()
        {
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(4, sphere);

            var comps = i.PrepareComputations(ray);
            Assert.IsFalse(comps.Inside);
        }
        [TestMethod]
        public void HitWhenIntersectionOccursOnInside()
        {
            var ray = new Ray(RayTuple.Point(0,0,0), RayTuple.Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(1, sphere);

            var comps = i.PrepareComputations(ray);
            RayTuple.Point(0,0,1).Assert(comps.Point);
            RayTuple.Vector(0,0,-1).Assert(comps.EyeV);
            Assert.IsTrue(comps.Inside);
            RayTuple.Vector(0,0,-1).Assert(comps.NormalV);
        }

        [TestInitialize]
        public void Setup()
        {
            Intersections.List.Clear();
        }
    }
}
