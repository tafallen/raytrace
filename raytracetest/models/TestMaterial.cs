namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestMaterial
    {
        [TestMethod]
        public void TestCreateSuccess()
        {
            var material = new Material();

            Assert.AreEqual( new Colour(1,1,1), material.Colour );
            Assert.AreEqual( 0.1, material.Ambient );
            Assert.AreEqual( 0.9, material.Diffuse );
            Assert.AreEqual( 0.9, material.Specular );
            Assert.AreEqual( 200.0, material.Shininess );
        }
    }
}
