namespace RayTraceTest.Engine
{
    using RayTraceTest.Assertors;
    using RayTrace.Engine;
    using RayTrace.Extensions;
    using RayTrace.Models;

    [TestClass]
    public class TestCannonEngine
    {
        [TestMethod]
        public void Test()
        {
            var projectile = new Projectile(
                new Point(0,1,0),
                new Vector(1,1,0).Normalise());
            var environment = new Environment(
                new Vector(0,-0.1,0),
                new Vector(-0.01,0,0));
            var engine = new CannonEngine(projectile,environment);   

            var result = engine.Tick();
            new Point(0.7071067811865475,1.7071067811865475,0)
                .Assert(result.Position);
            new Vector(0.6971067811865475,0.6071067811865475,0)
                .Assert(result.Velocity);
        }       
    }
}