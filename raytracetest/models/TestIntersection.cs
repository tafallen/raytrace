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
            var intersections = new Intersections();
            var sphere = new Sphere();
            var i1 = new Intersection(1, sphere);
            var i2 = new Intersection(2, sphere);
            intersections.Add(i1);
            intersections.Add(i2);
            
            var hit = intersections.Hit();
            Assert.AreEqual(i1, hit);
        }
        [TestMethod]
        public void FirstPositiveHitReturnedSucceeds()
        {
            var intersections = new Intersections();
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(3, sphere);
            intersections.Add(i1);
            intersections.Add(i2);
            
            var hit = intersections.Hit();
            Assert.AreEqual(i2, hit);
        }
        [TestMethod]
        public void EmptyIfNoPosHitSucceeds()
        {
            var intersections = new Intersections();
            var sphere = new Sphere();
            var i1 = new Intersection(-1, sphere);
            var i2 = new Intersection(-3, sphere);
            intersections.Add(i1);
            intersections.Add(i2);
            
            var hit = intersections.Hit();
            Assert.IsNull(hit);
        }
        [TestMethod]
        public void LowestHitReturnedSucceeds()
        {
            var intersections = new Intersections();
            var sphere = new Sphere();
            var i1 = new Intersection(5, sphere);
            var i2 = new Intersection(7, sphere);
            var i3 = new Intersection(-3, sphere);
            var i4 = new Intersection(2, sphere);
            intersections.Add(i1);
            intersections.Add(i2);
            intersections.Add(i3);
            intersections.Add(i4);
            
            var hit = intersections.Hit();
            Assert.AreEqual(i4, hit);
        }
        [TestMethod]
        public void PrecomputeIntersectionState()
        {
            var ray = new Ray(new Point(0,0,-5), new Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(4, sphere);

            var comps = i.PrepareComputations(ray);
            Assert.AreEqual(i.T, comps.Time);
            Assert.AreEqual(i.Element, comps.Element);
            new Vector(0,0,-1).Assert(comps.EyeV);
            new Vector(0,0,-1).Assert(comps.NormalV);
            new Point(0,0,-1).Assert(comps.Point);
        }
        [TestMethod]
        public void HitWhenIntersectionOccursOnOutside()
        {
            var ray = new Ray(new Point(0,0,-5), new Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(4, sphere);

            var comps = i.PrepareComputations(ray);
            Assert.IsFalse(comps.Inside);
        }
        [TestMethod]
        public void HitWhenIntersectionOccursOnInside()
        {
            var ray = new Ray(new Point(0,0,0), new Vector(0,0,1));
            var sphere = new Sphere();
            var i = new Intersection(1, sphere);

            var comps = i.PrepareComputations(ray);
            new Point(0,0,1).Assert(comps.Point);
            new Vector(0,0,-1).Assert(comps.EyeV);
            Assert.IsTrue(comps.Inside);
            new Vector(0,0,-1).Assert(comps.NormalV);
        }
    }
}
