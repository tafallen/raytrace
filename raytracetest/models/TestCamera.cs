namespace RayTraceTest.Models
{
    using RayTrace.Extensions;
    using RayTrace.Models;
    using RayTrace.Transforms;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestCamera
    {
        [TestMethod]
        public void CreateCameraSucceeds()
        {
            var camera = new Camera();

            Assert.AreEqual(160,camera.Hsize);
            Assert.AreEqual(120,camera.Vsize);
            Assert.AreEqual(Math.PI/2,camera.FieldOfView);
            Assert.AreEqual(Matrix.IdentityMatrix,camera.Transform.Matrix);
        }
        [TestMethod]
        public void HorizontalCanvasPixelSizeCalculationSucceeds()
        {
            var camera = new Camera(hsize: 200, vsize: 125);
            Assert.IsTrue(camera.PixelSize.IsEqual(0.01));
        }
        [TestMethod]
        public void VerticalCanvasPixelSizeCalculationSucceeds()
        {
            var camera = new Camera(hsize: 125, vsize: 200);
            Assert.IsTrue(camera.PixelSize.IsEqual(0.01));
        }
        [TestMethod]
        public void ConstructRayThroughCenterOfCanvas()
        {
            var camera = new Camera(201,101,Math.PI/2);
            Ray ray = camera.RayForPixel(100,50);

            new Point(0,0,0).Assert(ray.Point);
            new Vector(0,0,-1).Assert(ray.Direction);
        }
        [TestMethod]
        public void ConstructRayThroughCornerOfCanvas()
        {
            var camera = new Camera(201,101,Math.PI/2);
            Ray ray = camera.RayForPixel(0,0);

            new Point(0,0,0).Assert(ray.Point);
            new Vector(0.66519,0.33259,-0.66851).Assert(ray.Direction);
        }
        [TestMethod]
        public void ConstructRayThroughCenterTransformedCanvas()
        {
            var camera = new Camera(201,101,Math.PI/2);
            camera.Transform = RotateYTransform.RotateYMatrix(Math.PI/4) * TranslationTransform.TranslationMatrix(0,-2,5);
            Ray ray = camera.RayForPixel(100,50);

            new Point(0,2,-5).Assert(ray.Point);
            new Vector(Math.Sqrt(2)/2,0,-(Math.Sqrt(2)/2)).Assert(ray.Direction);
        }
        [TestMethod]
        public void RenderingWorldWithCamera()
        {
            var world = CreateDefaultWorld();
            var camera = new Camera(11,11,Math.PI/2);
            var from = new Point(0,0,-5);
            var to = new Point(0,0,0);
            var up = new Vector(0,1,0);
            camera.Transform = ViewTransform.ViewTransformMatrix(from, to, up);
            var image = camera.Render(world);
            new Colour(0.38066, 0.47583, 0.2855).Assert(image.GetPixel(5,5));
        }

        private World CreateDefaultWorld()
        {
            var world = new World();
            var light = new Light(){Position = new Point(-10,10,-10), Intensity = new Colour(1,1,1)};
            var s1Material = new Material(){Colour = new Colour(0.8,1.0,0.6), Diffuse=0.7,Specular=0.2};
            var s1 = new Sphere() { Material = s1Material };
            var s2 = new Sphere() { Transform = ScalingTransform.ScaleMatrix(0.5,0.5,0.5) };

            world.Light = light;
            world.Elements.Add(s1);
            world.Elements.Add(s2);
            return world;
        }
    }
}