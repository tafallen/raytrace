namespace RayTraceTest.Models
{
    using RayTrace.Transforms;
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
            var point = new Point(0,0,0);
            var eyev = new Vector(0,0,-1);
            var normalv = new Vector(0,0,-1);
            var light = new Light()
            {
                Position = new Point(0,0,-10),
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
            var point = new Point(0,0,0);
            var eyev = new Vector(0,Math.Sqrt(2)/2, -(Math.Sqrt(2)/2));
            var normalv = new Vector(0,0,-1);
            var light = new Light()
            {
                Position = new Point(0,0,-10),
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
            var point = new Point(0,0,0);
            var eyev = new Vector(0,0,-1);
            var normalv = new Vector(0,0,-1);
            var light = new Light()
            {
                Position = new Point(0,10,-10),
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
            var point = new Point(0,0,0);
            var eyev = new Vector(0,Math.Sqrt(2)/2, -(Math.Sqrt(2)/2));
            var normalv = new Vector(0,0,-1);
            var light = new Light()
            {
                Position = new Point(0,10,-10),
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
            var point = new Point(0,0,0);
            var eyev = new Vector(0,0,-1);
            var normalv = new Vector(0,0,-1);
            var light = new Light()
            {
                Position = new Point(0,0,10),
                Intensity = new Colour(1,1,1)
            };

            var result = material.Lighting(light, point, eyev, normalv);
            expected.Assert(result);
        }
        [TestMethod]
        public void LightingWithSurfaceInShadow()
        {
            var expected = new Colour(0.1,0.1,0.1);
            var material = new Material();
            var point = new Point(0,0,0);
            var eyev = new Vector(0,0,-1);
            var normalv = new Vector(0,0,-1);
            var light = new Light() 
            { 
                Position = new Point(0,0,-10), 
                Intensity = new Colour(1,1,1) 
            };
            var result = material.Lighting(light, point, eyev, normalv, true);
            expected.Assert(result);
        }
        [TestMethod]
        public void NoShadowNothingColinearWithPointAndLight()
        {
            var world = CreateDefaultWorld();
            var point = new Point(0,10,0);

            Assert.IsFalse(world.IsShadowed(point));
        }
        [TestMethod]
        public void ShadowObjectBetweenPointAndLight()
        {
            var world = CreateDefaultWorld();
            var point = new Point(10,-10,10);

            Assert.IsTrue(world.IsShadowed(point));
        }
        [TestMethod]
        public void NoShadowObjectBehindLight()
        {
            var world = CreateDefaultWorld();
            var point = new Point(-20,20,-20);

            Assert.IsFalse(world.IsShadowed(point));
        }
        [TestMethod]
        public void NoShadowObjectBehindPoint()
        {
            var world = CreateDefaultWorld();
            var point = new Point(-2,2,-2);

            Assert.IsFalse(world.IsShadowed(point));
        }

        private World CreateDefaultWorld()
        {
            var world = new World();
            var light = new Light(){Position = new Point(-10,10,-10), Intensity = new Colour(1,1,1)};
            var s1Material = new Material(){Colour = new Colour(0.8,1.0,0.6), Diffuse=0.7,Specular=0.2};
            var s1 = new Sphere() { Material = s1Material };
            var s2 = new Sphere() { Transform = Transformation.Scale(0.5,0.5,0.5) };

            world.Light = light;
            world.Add(s1);
            world.Add(s2);
            return world;
        }
    }
}
