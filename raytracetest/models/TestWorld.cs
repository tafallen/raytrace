namespace RayTraceTest.Models
{
    using System.Collections.Generic;
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    using RayTraceTest.Assertors;

    [TestClass]
    public class TestWorld
    {
        [TestMethod] 
        public void CreateWorldSuccess()
        {
            var world = new World();
            Assert.AreEqual(0, world.GetElements().Count);
        }
        [TestMethod]
        public void CreateDefaultWorldSuccess()
        {
            var world = new World();
            var light = new Light(){Position = new Point(-10,10,-10), Intensity = new Colour(1,1,1)};
            var s1Material = new Material(){Colour = new Colour(0.8,1.0,0.6), Diffuse=0.7,Specular=0.2};
            var s1 = new Sphere() { Material = s1Material };
            var s2 = new Sphere() { Transform = Transformation.Scale(0.5,0.5,0.5) };

            world.Light = light;
            world.Add(s1);
            world.Add(s2);

            Assert.AreEqual(light, world.Light);
            Assert.IsTrue(world.GetElements().Contains(s1));
            Assert.IsTrue(world.GetElements().Contains(s2));
        }
        [TestMethod]
        public void IntersectWorldWithRay()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(new Point(0,0,-5), new Vector(0,0,1));
            
            var intersect = world.Intersect(ray).OrderBy(x=>x.T).ToList();

            Assert.AreEqual(4, intersect.Count);
            Assert.AreEqual(4,intersect[0].T);
            Assert.AreEqual(4.5,intersect[1].T);
            Assert.AreEqual(5.5,intersect[2].T);
            Assert.AreEqual(6,intersect[3].T);
        }
        [TestMethod]
        public void ShadingIntersection()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(new Point(0,0,-5), new Vector(0,0,1));
            var shape = world.GetElements().First();
            var i = new Intersection(4,shape);

            var comps = i.PrepareComputations(ray);
            var c = world.ShadeHit(comps);
            new Colour(0.38066, 0.47583, 0.2855).Assert(c);
        }
        [TestMethod]
        public void ShadingIntersectionOutside()
        {
            var world = CreateDefaultWorld();
            world.Light = new Light()
            {
                Position = new Point(0,0.25,0),
                Intensity = new Colour(1,1,1)
            };
            var ray = new Ray(new Point(0,0,0), new Vector(0,0,1));
            var shape = world.GetElements().Skip(1).First();
            var i = new Intersection(0.5,shape);

            var comps = i.PrepareComputations(ray);
            var c = world.ShadeHit(comps);
            new Colour(0.90498, 0.90498, 0.90498).Assert(c);
        }
        [Ignore]
        [TestMethod]
        public void ColourWhenRayMisses()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(new Point(0,0,-5), new Vector(0,1,0));

            var c = world.ColourAt(ray);
            new Colour(0,0,0).Assert(c);
        }
        [TestMethod]
        public void ColourWhenRayHits()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(new Point(0,0,-5), new Vector(0,0,1));

            var c = world.ColourAt(ray);
            new Colour(0.38066,0.47583,0.2855).Assert(c);
        }
        [TestMethod]
        public void ColourIntersectionBehindRay()
        {
            var world = CreateDefaultWorld();
            var outer = world.GetElements().First();
            var inner = world.GetElements().Last();
            outer.Material.Ambient = 1;
            inner.Material.Ambient = 1;
            var ray = new Ray(new Point(0,0,0.75), new Vector(0,0,-1));

            inner.Material.Colour.Assert(world.ColourAt(ray));
        }
        [Ignore]
        [TestMethod]
        public void ShadeHitGivenIntersectionInShadow()
        {
            var world = CreateDefaultWorld();
            world.Light = new Light(new Point(0,0,-10),new Colour(1,1,1));
            var sphere1 = new Sphere();
            world.Add(sphere1);

            var sphere2 = new Sphere()
            {
                Transform = Transformation.Translation(0,0,10)
            };
            world.Add(sphere2);
            var ray = new Ray(new Point(0,0,5), new Vector(0,0,1));
            var intersection = new Intersection(4, sphere2);
            var comps = intersection.PrepareComputations(ray);
            var expected = world.ShadeHit(comps);
            new Colour(0.1,0.1,0.1).Assert(expected);
        }
        [Ignore]
        [TestMethod]
        public void HitShouldOffsetPoint()
        {
            var ray = new Ray(new Point(0,0,-5),new Vector(0,0,1));
            var sphere = new Sphere()
            {
                Transform = Transformation.Translation(0,0,1)
            };
            var intersection = new Intersection(5, sphere);
            var comps = intersection.PrepareComputations(ray);
            Assert.IsTrue(comps.OverPoint.Z < -DoubleExtensions.EPSILON/2);
            Assert.IsTrue(comps.Point.Z > comps.OverPoint.Z);
        }

        // This is repeated too often. DRY it out!
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