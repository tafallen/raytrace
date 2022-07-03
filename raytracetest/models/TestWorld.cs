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
            Assert.IsNull(world.Light);
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
    }
}