using RayTrace.Extensions;

namespace RayTrace.Models
{
    public class Point: RayTuple
    {

        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
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
        public static Point operator *(Point a, double multiplier)
        {
            return new Point(a.X * multiplier, a.Y * multiplier, a.Z * multiplier);
        }
        public static Point operator /(Point a, double divisor)
        {
            return new Point(a.X / divisor, a.Y / divisor, a.Z / divisor);
        }
        public override bool Equals(object? obj)
        {
            if(base.Equals(obj))
                return true;
            var x = obj as Point;
            if(x==null)
                return false;
            else 
                return Equals(x);
        }
        public bool Equals(Point other)
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
            return $"Point: ({X},{Y},{Z})";            
        }
    }

    // public class RayTuple
    // {
    //     private (double X, double Y, double Z, RayTupleType type) coords;
       
    //     public RayTuple(double x = 0.0, double y =0.0, double z=0.0, RayTupleType tupleType = RayTupleType.Point)
    //     {
    //         coords.X = x;
    //         coords.Y = y;
    //         coords.Z = z;
    //         coords.type = tupleType;
    //     }
    //     // public static RayTuple Vector(double x, double y, double z)
    //     // {
    //     //     return new RayTuple(x,y,z,RayTupleType.Vector);
    //     // }
    //     public static RayTuple Point(double x, double y, double z)
    //     {
    //         return new RayTuple(x,y,z,RayTupleType.Point);
    //     }
    //     public RayTupleType Type => coords.type;

    //     public double X { get => coords.X; set => coords.X = value; }
    //     public double Y { get => coords.Y; set => coords.Y = value; }
    //     public double Z { get => coords.Z; set => coords.Z = value; }

    //     public static RayTuple operator +(RayTuple a, RayTuple b)
    //     {
    //         var t = (a.Type).Add(b.Type);
    //         var x = a.X + b.X;
    //         var y = a.Y + b.Y;
    //         var z = a.Z + b.Z;

    //         return new RayTuple(x,y,z,t);
    //     }
    //     public static RayTuple operator -(RayTuple a, RayTuple b)
    //     {
    //         var t = (a.Type).Subtract(b.Type);
    //         var x = a.X - b.X;
    //         var y = a.Y - b.Y;
    //         var z = a.Z - b.Z;

    //         return new RayTuple(x,y,z,t);
    //     }
    //     public static RayTuple operator !(RayTuple a)
    //     {
    //         return RayTuple.Vector(0,0,0) - a;
    //     }
    //     public static RayTuple operator *(RayTuple a, double multiplier)
    //     {
    //         return new RayTuple(a.X * multiplier, a.Y * multiplier, a.Z * multiplier, a.Type);
    //     }
    //     public static RayTuple operator /(RayTuple a, double divisor)
    //     {
    //         return new RayTuple(a.X / divisor, a.Y / divisor, a.Z / divisor, a.Type);
    //     }
    //     public override bool Equals(object? obj)
    //     {
    //         if( base.Equals(obj) )
    //             return true;
    //         else if( obj == null )
    //             return false;
    //         else
    //             return Equals((RayTuple)obj); 
    //     }
    //     public bool Equals(RayTuple other)
    //     {
    //         return (other.X.IsEqual(this.X) &&
    //                 other.Y.IsEqual(this.Y) &&
    //                 other.Z.IsEqual(this.Z) &&
    //                 other.Type == this.Type);
    //     }
    //     public override int GetHashCode()
    //     {
    //         return coords.GetHashCode() + Type.GetHashCode();
    //     }
    //     public override string ToString()
    //     {
    //         return $"({coords.X},{coords.Y},{coords.Z},{Type})";            
    //     }
    // }
}