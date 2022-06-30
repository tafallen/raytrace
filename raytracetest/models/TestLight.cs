namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestLight
    {
        [TestMethod]
        public void TestCreateLightSuccess()
        {
            var pos = RayTuple.Point(0,0,0);
            var col = new Colour(1,1,1);
            var light = new Light()
            {
                Position = pos,
                Intensity = col
            };

            Assert.AreEqual(pos, light.Position);
            Assert.AreEqual(col, light.Intensity);
        }
    }
}
