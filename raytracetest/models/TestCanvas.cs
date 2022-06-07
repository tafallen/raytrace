namespace RayTraceTest.Models
{
    using System.Text;
    using RayTrace.Models;

    [TestClass]
    public class TestCanvas
    {
        [TestMethod]
        public void TestCreateCanvasSuccess()
        {
            var canvas = new Canvas(10,20);

            Assert.AreEqual(10,canvas.Width);
            Assert.AreEqual(20,canvas.Height);

            for(var i=0; i<9; i++)
                for(var j=0;j<19;j++)
                    Assert.AreEqual(new Colour(0.0,0.0,0.0), canvas.GetPixel(i,j));
        }

        [TestMethod]
        public void TestWritePixelSuccess()
        {
            var canvas = new Canvas(10,20);

            canvas.WritePixel(2,3,new Colour(1,0,0));

            Assert.AreEqual(new Colour(1,0,0), canvas.GetPixel(2,3));
        }
        
        [TestMethod]
        public void TestToPPMHeaderSuccess()
        {
            var canvas = new Canvas(10,20);

            StringBuilder result = new StringBuilder();
            result.AppendLine("P3").AppendLine("10 20").AppendLine("255");
            var expectedResult = result.ToString();
            var actualResult = canvas.ToPPM();

            Assert.IsTrue(actualResult.StartsWith(expectedResult));
        }
        
        [TestMethod]
        public void TestToPPMSuccess()
        {
            var canvas = new Canvas(5,3);

            StringBuilder result = new StringBuilder();
            result.AppendLine("P3").AppendLine("5 3").AppendLine("255");
            result.AppendLine("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
            result.AppendLine("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
            result.AppendLine("0 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
            var expectedResult = result.ToString();
            var actualResult = canvas.ToPPM();

            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestMethod]
        public void TestToPPMWithColoursSuccess()
        {
            var canvas = new Canvas(5,3);
            canvas.WritePixel(0,0,new Colour(1.5,0,0));
            canvas.WritePixel(2,1,new Colour(0,0.5,0));
            canvas.WritePixel(4,2,new Colour(-0.5,0,1));

            StringBuilder result = new StringBuilder();
            result.AppendLine("P3").AppendLine("5 3").AppendLine("255");
            result.AppendLine("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
            result.AppendLine("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0");
            result.AppendLine("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255");

            Assert.AreEqual(result.ToString(), canvas.ToPPM());
        }

        [TestMethod]
        public void TestToPPMLineSplittingSuccess()
        {
            var canvas = new Canvas(10,2);
            canvas.Fill(new Colour(1,0.8,0.6));

            StringBuilder result = new StringBuilder();
            result.AppendLine("P3").AppendLine("10 2").AppendLine("255");
            result.AppendLine("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204");
            result.AppendLine("153 255 204 153 255 204 153 255 204 153 255 204 153");
            result.AppendLine("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204");
            result.AppendLine("153 255 204 153 255 204 153 255 204 153 255 204 153");

            Assert.AreEqual(result.ToString(), canvas.ToPPM());
        }
    }
}
