using RayTrace.Extensions;
using System;

namespace RayTrace.Models
{
    public class RayTuple
    {
        private (double X, double Y, double Z) coords;

        public static RayTuple Vector(double x, double y, double z)
        {
            return new RayTuple(x,y,z,RayTupleType.Vector);
        }
        public static RayTuple Point(double x, double y, double z)
        {
            return new RayTuple(x,y,z,RayTupleType.Point);
        }
        public RayTupleType Type { get; set; }

        public double X { get => coords.X; set => coords.X = value; }
        public double Y { get => coords.Y; set => coords.Y = value; }
        public double Z { get => coords.Z; set => coords.Z = value; }

        public bool Equals(RayTuple other)
        {
            return (other.X.equals(this.X) &&
                    other.Y.equals(this.Y) &&
                    other.Z.equals(this.Z) &&
                    other.Type == this.Type);
        }

        public static RayTuple operator +(RayTuple a, RayTuple b)
        {
            var t = (a.Type).Add(b.Type);
            var x = a.X + b.X;
            var y = a.Y + b.Y;
            var z = a.Z + b.Z;

            return new RayTuple(x,y,z,t);
        }

        public static RayTuple operator -(RayTuple a, RayTuple b)
        {
            var t = (a.Type).Subtract(b.Type);
            var x = a.X - b.X;
            var y = a.Y - b.Y;
            var z = a.Z - b.Z;

            return new RayTuple(x,y,z,t);
        }

        public static RayTuple operator !(RayTuple a)
        {
            return RayTuple.Vector(0,0,0) - a;
        }

        public static RayTuple operator *(RayTuple a, double multiplier)
        {
            return new RayTuple(a.X * multiplier, a.Y * multiplier, a.Z * multiplier, a.Type);
        }

        public static RayTuple operator /(RayTuple a, double divisor)
        {
            return new RayTuple(a.X / divisor, a.Y / divisor, a.Z / divisor, a.Type);
        }

        

        public override bool Equals(object? obj)
        {
            if( base.Equals(obj) )
                return true;
            else if( obj == null )
                return false;
            else
                return Equals((RayTuple)obj); 
        }

        public override int GetHashCode()
        {
            return coords.GetHashCode() + Type.GetHashCode();
        }

        public override string ToString()
        {
            return $"({coords.X},{coords.Y},{coords.Z},{Type})";            
        }
       
        private RayTuple(double x = 0.0, double y =0.0, double z=0.0, RayTupleType tupleType = RayTupleType.Point)
        {
            coords.X = x;
            coords.Y = y;
            coords.Z = z;

            Type = tupleType;
        }
    }
}