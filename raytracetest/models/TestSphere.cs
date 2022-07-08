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
            Assert.AreEqual(new Material(), sphere.Material);
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
            var ray = new Ray(new Point(0,0,-5),new Vector(0,0,1));
            var scaling = ScalingTransform.ScaleMatrix(2,2,2);
            sphere.Transform = scaling;

            var intersects = sphere.Intersect(ray);

            Assert.AreEqual(2, intersects.Count);
        }
        [TestMethod]
        public void IntersectTranslatedSphereWithRayMisses()
        {
            var sphere = new Sphere();
            var ray = new Ray(new Point(0,0,-5),new Vector(0,0,1));
            var translate = TranslationTransform.TranslationMatrix(5,0,0);
            sphere.Transform = translate;

            var intersects = sphere.Intersect(ray);

            Assert.AreEqual(0, intersects.Count);
        }
        [TestMethod]
        public void NormalAtAPointOnXAxis()
        {
            var sphere = new Sphere();
            var expected = new Vector(1,0,0);

            var actual = sphere.NormalAt(new Point(1,0,0));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtAPointOnYAxis()
        {
            var sphere = new Sphere();
            var expected = new Vector(0,1,0);

            var actual = sphere.NormalAt(new Point(0,1,0));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtAPointOnZAxis()
        {
            var sphere = new Sphere();
            var expected = new Vector(0,0,1);

            var actual = sphere.NormalAt(new Point(0,0,1));

            expected.Assert(actual);
        }
        [TestMethod]
        public void NormalAtNonaxialPoint()
        {
            var sphere = new Sphere();
            var expected = new Vector(Math.Sqrt(3)/3,Math.Sqrt(3)/3,Math.Sqrt(3)/3);
            var vector = sphere.NormalAt(new Point(Math.Sqrt(3)/3, Math.Sqrt(3)/3, Math.Sqrt(3)/3));

            expected.Assert(vector);
        }
        [TestMethod]
        public void NormalAtIsNormalised()
        {
            var sphere = new Sphere();
            var vector = sphere.NormalAt( new Point(Math.Sqrt(3)/3, Math.Sqrt(3)/3, Math.Sqrt(3)/3));

            vector.Assert(vector.Normalise());
        }
        [TestMethod]
        public void NormalOnTranslatedSphere()
        {
            var sphere = new Sphere();
            sphere.Transform = TranslationTransform.TranslationMatrix(0,1,0);

            var actual = sphere.NormalAt(new Point(0, 1.70711, -0.70711));

            new Vector(0,0.70711, -0.70711)
                    .Assert(actual);
        }
        [TestMethod]
        public void NormalOnTransformedSphere()
        {
            var sphere = new Sphere();
            sphere.Transform = ScalingTransform.ScaleMatrix(1,0.5,1) * RotateZTransform.RotateZMatrix(Math.PI/5);
            var point = new Point(0, Math.Sqrt(2)/2, -(Math.Sqrt(2)/2));

            var actual = sphere.NormalAt(point);

            new Vector(0, 0.97014, -0.24254)
                    .Assert(actual);
        }
        [TestMethod]
        public void AssignMaterialSucceeds()
        {
            var sphere = new Sphere();
            var material = new Material(){ Colour = new Colour(0.5, 0.5, 0) };

            sphere.Material = material;

            Assert.AreEqual(material, sphere.Material);
        }
    }
}