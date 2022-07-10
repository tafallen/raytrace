namespace RayTrace.Models
{
    public class Vector : Spatial
    {
        public Vector(double x, double y, double z) : base(x,y,z) { }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector operator !(Vector a)
        {
            return new Vector(0,0,0) - a;
        }
        public static Vector operator *(Vector a, double multiplier)
        {
            return new Vector(a.X * multiplier, a.Y * multiplier, a.Z * multiplier);
        }
        public static Vector operator /(Vector a, double divisor)
        {
            return new Vector(a.X / divisor, a.Y / divisor, a.Z / divisor);
        }
        public override string ToString()
        {
            return $"Vector: ({X},{Y},{Z})";            
        }
    }
}