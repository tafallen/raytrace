namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestSphere
    {
        [TestInitialize]
        public void Setup()
        {
            Intersections.List.Clear();
        }
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
            var transform = TranslationTransform.TranslationMatrix(2,3,4);;

            sphere.Transform = transform;

            Assert.AreEqual(transform, sphere.Transform);
        }
        [TestMethod]
        public void IntersectScaledSphereWithRaySucceeds()
        {
            var sphere = new Sphere();
            var ray = new Ray(RayTuple.Point(0,0,-5),RayTuple.Vector(0,0,1));
            var scaling = ScalingTransform.ScaleMatrix(2,2,2);
            sphere.Transform = scaling;

            var intersects = sphere.Intersect(ray);

            Assert.AreEqual(2, intersects.Count);
        }
        [TestMethod]
        public void IntersectTranslatedSphereWithRayMisses()
        {
            var sphere = new Sphere();
            var ray = new Ray(RayTuple.Point(0,0,-5),RayTuple.Vector(0,0,1));
            var translate = TranslationTransform.TranslationMatrix(5,0,0);
            sphere.Transform = translate;

            var intersects = sphere.Intersect(ray);

            Assert.AreEqual(0, intersects.Count);
        }
        [TestMethod]
        public void NormalAtAPointOnXAxis()
        {
            var sphere = new Sphere();
            var expected = RayTuple.Vector(1,0,0);

            var actual = sphere.NormalAt(RayTuple.Point(1,0,0));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtAPointOnYAxis()
        {
            var sphere = new Sphere();
            var expected = RayTuple.Vector(0,1,0);

            var actual = sphere.NormalAt(RayTuple.Point(0,1,0));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtAPointOnZAxis()
        {
            var sphere = new Sphere();
            var expected = RayTuple.Vector(0,0,1);

            var actual = sphere.NormalAt(RayTuple.Point(0,0,1));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtIsNormalised()
        {
            var sphere = new Sphere();
            var vector = sphere.NormalAt( RayTuple.Point(Math.Sqrt(3)/3, Math.Sqrt(3)/3, Math.Sqrt(3)/3));

            vector.Assert(vector.Normalise());
        }
    }
}