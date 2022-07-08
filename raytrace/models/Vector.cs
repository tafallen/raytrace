using RayTrace.Extensions;

namespace RayTrace.Models
{
    public class Vector : RayTuple
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
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
        public override bool Equals(object? obj)
        {
            if(base.Equals(obj))
                return true;
            var x = obj as Vector;
            if(x==null)
                return false;
            else 
                return Equals(x);
        }
        public bool Equals(Vector other)
        {
            return (other.X.IsEqual(this.X) &&
                    other.Y.IsEqual(this.Y) &&
                    other.Z.IsEqual(this.Z));
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Y.GetHashCode();
        }
        public override string ToString()
        {
            return $"Vector: ({X},{Y},{Z})";            
        }
    }
}