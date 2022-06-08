namespace RayTrace.Models
{
    using System.Text;

    public class Canvas
    {
        private Colour[,] canvas;

        public int Width {get;set;}
        public int Height {get;set;}
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;
            canvas = new Colour[width,height];
            Fill(new Colour());
        }
        public Colour GetPixel(int x, int y)
        {
            if(IsXInvalid(x) || IsYInvalid(y))
                throw new ArgumentException($"GetPixel(): requested {x},{y} in canvas {Width},{Height}");

            return canvas[x,y].Duplicate();
        }
        public void WritePixel(int x, int y, Colour colour)
        {
            if(IsXInvalid(x) || IsYInvalid(y))
            {
                throw new ArgumentException($"WritePixel(): requested {x},{y} in canvas {Width},{Height}");
            }
            canvas[x,y] = colour;
        }
        public void Fill(Colour colour)
        {
            for(var i=0; i<Width; i++)
                for(var j=0;j<Height;j++)
                    canvas[i,j] = colour.Duplicate();
        }
        public string ToPPM()
        {
            StringBuilder result = new StringBuilder(GetPPMHeader());
            
            for(var i = 0; i <Height; i++)
                result = GetPPMCanvasLine(result,i);
 
            return result.ToString();
        }
        private StringBuilder GetPPMCanvasLine(StringBuilder result, int row)
        {
            var line = BuildPPMCanvasLine(row);
            if( line.Length > 70)
            {
                var splitPoint = line.IndexOf(' ',66);
                var firstLine = line.Substring(0,splitPoint);
                result.AppendLine(firstLine.TrimEnd());
                line = line.Substring(splitPoint+1);
            }
            result.AppendLine(line.TrimEnd());
            return result;
        }
        private string BuildPPMCanvasLine(int row)
        {
            StringBuilder line = new StringBuilder();
            for(var column = 0; column <Width; column++)
                line.Append($"{GetPixel(column,row).ToPPM(255)} ");

            return line.ToString();
        }
        private string GetPPMHeader()
        {
            StringBuilder result = new StringBuilder();
            
            result.AppendLine("P3");
            result.AppendLine($"{Width} {Height}");
            result.AppendLine("255");

            return result.ToString();
        }
        private bool IsXInvalid(int x)
        {
            return (x < 0 || x > Width -1);
        }
        private bool IsYInvalid(int y)
        {
            return (y < 0 || y > Height -1);
        }
    }
}