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
            Assert.AreEqual(0, world.Elements.Count);
        }
        [TestMethod]
        public void CreateDefaultWorldSuccess()
        {
            var world = new World();
            var light = new Light(){Position = RayTuple.Point(-10,10,-10), Intensity = new Colour(1,1,1)};
            var s1Material = new Material(){Colour = new Colour(0.8,1.0,0.6), Diffuse=0.7,Specular=0.2};
            var s1 = new Sphere() { Material = s1Material };
            var s2 = new Sphere() { Transform = ScalingTransform.ScaleMatrix(0.5,0.5,0.5) };

            world.Light = light;
            world.Elements.Add(s1);
            world.Elements.Add(s2);

            Assert.AreEqual(light, world.Light);
            Assert.IsTrue(world.Elements.Contains(s1));
            Assert.IsTrue(world.Elements.Contains(s2));
        }
        [TestMethod]
        public void IntersectWorldWithRay()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,0,1));
            
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
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,0,1));
            var shape = world.Elements.First();
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
                Position = RayTuple.Point(0,0.25,0),
                Intensity = new Colour(1,1,1)
            };
            var ray = new Ray(RayTuple.Point(0,0,0), RayTuple.Vector(0,0,1));
            var shape = world.Elements.Skip(1).First();
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
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,1,0));

            var c = world.ColourAt(ray);
            new Colour(0,0,0).Assert(c);
        }
        [TestMethod]
        public void ColourWhenRayHits()
        {
            var world = CreateDefaultWorld();
            var ray = new Ray(RayTuple.Point(0,0,-5), RayTuple.Vector(0,0,1));

            var c = world.ColourAt(ray);
            new Colour(0.38066,0.47583,0.2855).Assert(c);
        }
        [TestMethod]
        public void ColourIntersectionBehindRay()
        {
            var world = CreateDefaultWorld();
            var outer = world.Elements.First();
            var inner = world.Elements.Last();
            outer.Material.Ambient = 1;
            inner.Material.Ambient = 1;
            var ray = new Ray(RayTuple.Point(0,0,0.75), RayTuple.Vector(0,0,-1));

            inner.Material.Colour.Assert(world.ColourAt(ray));
        }

        private World CreateDefaultWorld()
        {
            var world = new World();
            var light = new Light(){Position = RayTuple.Point(-10,10,-10), Intensity = new Colour(1,1,1)};
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