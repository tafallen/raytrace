namespace RayTraceTest.Models
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTraceTest.Assertors;


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

            sphere.Transform = TranslationTransform.TranslationMatrix(2,3,4);
            
            TranslationTransform.TranslationMatrix(2,3,4)
                                .Assert(sphere.Transform);
        }
        // [TestMethod]
        // public void IntersectScaledSphereWithRaySucceeds()
        // {
        //     var ray = new Ray(RayTuple.Point(0,0,-5),RayTuple.Vector(0,0,1));
        //     var sphere = new Sphere();

        //     sphere.Transform = ScalingTransform.ScaleMatrix(2,2,2);

        //     var rayTransform = ((ScalingTransform)sphere.Transform).Inverse();
        //     // var scaledRay = ray.Scale(rayTransform);

        //     // var intersections = sphere.Intersect(scaledRay);
        //     // Assert.Fail();
        // }
    }
}