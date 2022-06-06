namespace RayTraceTest.Models
{
    using RayTrace.Models;

    [TestClass]
    public class TestColour
    {
        [TestMethod]
        public void TestColourCreateSucceeds()
        {
            new Colour(-0.5,0.4,1.7).Assert(-0.5,0.4,1.7);
        }

        [TestMethod]
        public void TestColourAddSucceeds()
        {
            var colour1 = new Colour(0.9,0.6,0.75);
            var colour2 = new Colour(0.7,0.1,0.25);

            new Colour(1.6,0.7,1.0).Assert(colour1+colour2);
        }
        
        [TestMethod]
        public void TestColourSubtractSucceeds()
        {
            var colour1 = new Colour(0.9,0.6,0.75);
            var colour2 = new Colour(0.7,0.1,0.25);

            new Colour(0.2,0.5,0.5).Assert(colour1-colour2);
        }
        
        [TestMethod]
        public void TestColourScalarMultiplySucceeds()
        {
            var colour1 = new Colour(0.2,0.3,0.4);

            new Colour(0.4,0.6,0.8).Assert(colour1*2);
        }
        
        [TestMethod]
        public void TestColourMultiplySucceeds()
        {
            var colour1 = new Colour(1,0.2,0.4);
            var colour2 = new Colour(0.9,1,0.1);

            new Colour(0.9,0.2,0.04).Assert(colour1*colour2);
        }
    }
}