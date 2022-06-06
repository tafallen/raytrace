namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestCanvas
    {
        [TestMethod]
        public void TestCreateCanvas()
        {
            var canvas = new Canvas(10,20);

            Assert.AreEqual(10,canvas.Width);
            Assert.AreEqual(20,canvas.Height);

            for(var i=0; i<10; i++)
            {
                for(var j=0;j<20;j++)
                {
                    Assert.AreEqual(new Colour(0.0,0.0,0.0),canvas.GetPixel(i,j));
                }
            }
        }
    }
}
