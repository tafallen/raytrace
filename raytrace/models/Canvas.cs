namespace RayTrace.Models
{
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
            {
                throw new ArgumentException($"GetPixel(): requested {x},{y} in canvas {Width},{Height}");
            }
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

        private void Fill(Colour colour)
        {
            for(var i=0; i<Width; i++)
            {
                for(var j=0;j<Height;j++)
                {
                    canvas[i,j] = colour;
                }
            }
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