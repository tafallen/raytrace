namespace RayTraceTest.Models
{
    using RayTrace.Extensions;
    using RayTrace.Models;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestMaterial
    {
        [TestMethod]
        public void CreateSuccess()
        {
            var material = new Material();

            Assert.AreEqual( new Colour(1,1,1), material.Colour );
            Assert.AreEqual( 0.1, material.Ambient );
            Assert.AreEqual( 0.9, material.Diffuse );
            Assert.AreEqual( 0.9, material.Specular );
            Assert.AreEqual( 200.0, material.Shininess );
        }
        [TestMethod]
        public void LightingEyeBetweenLightAndSurface()
        {
            var expected = new Colour(1.9,1.9,1.9);
            var material = new Material();
            var point = RayTuple.Point(0,0,0);
            var eyev = RayTuple.Vector(0,0,-1);
            var normalv = RayTuple.Vector(0,0,-1);
            var light = new Light()
            {
                Position = RayTuple.Point(0,0,-10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
        [TestMethod]
        public void LightingEyeBetweenLightAndSurfaceoffset45deg()
        {
            var expected = new Colour(1.0,1.0,1.0);
            var material = new Material();
            var point = RayTuple.Point(0,0,0);
            var eyev = RayTuple.Vector(0,Math.Sqrt(2)/2, -(Math.Sqrt(2)/2));
            var normalv = RayTuple.Vector(0,0,-1);
            var light = new Light()
            {
                Position = RayTuple.Point(0,0,-10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
        [TestMethod]
        public void LightingEyeOppositeSurfaceLightOffset45deg()
        {
            var expected = new Colour(0.7364,0.7364,0.7364);
            var material = new Material();
            var point = RayTuple.Point(0,0,0);
            var eyev = RayTuple.Vector(0,0,-1);
            var normalv = RayTuple.Vector(0,0,-1);
            var light = new Light()
            {
                Position = RayTuple.Point(0,10,-10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
        [TestMethod]
        public void LightingEyeInPathOfRefletionVector()
        {
            var expected = new Colour(1.6364,1.6364,1.6364);
            var material = new Material();
            var point = RayTuple.Point(0,0,0);
            var eyev = RayTuple.Vector(0,Math.Sqrt(2)/2, -(Math.Sqrt(2)/2));
            var normalv = RayTuple.Vector(0,0,-1);
            var light = new Light()
            {
                Position = RayTuple.Point(0,10,-10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
        [TestMethod]
        public void LightingWithLightBehindSurface()
        {
            var expected = new Colour(0.1,0.1,0.1);
            var material = new Material();
            var point = RayTuple.Point(0,0,0);
            var eyev = RayTuple.Vector(0,0,-1);
            var normalv = RayTuple.Vector(0,0,-1);
            var light = new Light()
            {
                Position = RayTuple.Point(0,0,10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
    }
}
