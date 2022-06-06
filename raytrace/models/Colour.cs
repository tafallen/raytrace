namespace RayTrace.Models
{
    public class Colour
    {
        private static int ROUNDING = 9;

        private (double r, double g, double b ) col;

        public double R { get => col.r; set => col.r = value; }
        public double G { get => col.g; set => col.g = value; }
        public double B { get => col.b; set => col.b = value; }

        public Colour( double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static Colour operator +(Colour a,Colour b)
        {
            return new Colour(Math.Round(a.R+b.R,ROUNDING), Math.Round(a.G+b.G,ROUNDING), Math.Round(a.B+b.B,ROUNDING));
        }

        public static Colour operator -(Colour a,Colour b)
        {
            return new Colour(Math.Round(a.R-b.R,ROUNDING), Math.Round(a.G-b.G,ROUNDING), Math.Round(a.B-b.B,ROUNDING));
        }

        public static Colour operator *(Colour a, double b)
        {
            return new Colour(Math.Round(a.R * b,ROUNDING), Math.Round(a.G * b,ROUNDING), Math.Round(a.B * b,ROUNDING));
        }

        public static Colour operator *(Colour a, Colour b)
        {
            return new Colour(Math.Round(a.R*b.R,ROUNDING), Math.Round(a.G*b.G, ROUNDING), Math.Round(a.B*b.B,ROUNDING));
        }
    }
}