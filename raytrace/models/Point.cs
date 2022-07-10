namespace RayTrace.Models
{
    public class Point: Spatial
    {
        public Point(double x, double y, double z) : base(x,y,z) { }
        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Point a, Point b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Point operator -(Point a, Vector b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Point operator !(Point a)
        {
            return new Point(-a.X,-a.Y,-a.Z);
        }
        public static Point operator *(Point a, Vector b)
        {
            return new Point(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        public static Point operator *(Point a, double multiplier)
        {
            return new Point(a.X * multiplier, a.Y * multiplier, a.Z * multiplier);
        }
        public static Point operator /(Point a, double divisor)
        {
            return new Point(a.X / divisor, a.Y / divisor, a.Z / divisor);
        }
        public override string ToString()
        {
            return $"Point: ({X},{Y},{Z})";            
        }
    }
}