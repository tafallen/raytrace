namespace RayTrace.Models
{
    using RayTrace.Extensions;
    public class Colour
    {
        private static int ROUNDING = 9;

        private (double r, double g, double b ) col;

        public double R { get => col.r; set => col.r = value; }
        public double G { get => col.g; set => col.g = value; }
        public double B { get => col.b; set => col.b = value; }

        public Colour( double r = 0.0, double g = 0.0, double b = 0.0)
        {
            R = r;
            G = g;
            B = b;
        }

        public Colour Duplicate()
        {
            return new Colour(R,G,B);
        }

        public override string ToString()
        {
            return $"({R},{G},{B})";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || (obj as Colour) == null)
            {
                return false;
            }
            var other = (Colour)obj;
            return( this.R.IsEqual(other.R) &&
                    this.G.IsEqual(other.G) &&
                    this.B.IsEqual(other.B));
        }

        public override int GetHashCode()
        {
            return R.GetHashCode() + G.GetHashCode() + B.GetHashCode();
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