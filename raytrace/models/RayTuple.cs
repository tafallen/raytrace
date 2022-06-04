using RayTrace.Extensions;
using System;

namespace RayTrace.Models
{
    public class RayTuple
    {
        public static RayTuple Vector(double x, double y, double z)
        {
            return new RayTuple(x,y,z,RayTupleType.Vector);
        }
        public static RayTuple Point(double x, double y, double z)
        {
            return new RayTuple(x,y,z,RayTupleType.Point);
        }
        public RayTupleType Type { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

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
            var zero = RayTuple.Vector(0,0,0);
            return zero - a;
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
            return X.GetHashCode() + 
                    Y.GetHashCode() + 
                    Z.GetHashCode() + 
                    Type.GetHashCode();
        }
        public override string ToString()
        {
            return $"({X},{Y},{Z},{Type})";            
        }
        private RayTuple(double x = 0.0, double y =0.0, double z=0.0, RayTupleType tupleType = RayTupleType.Point)
        {
            X = x;
            Y = y;
            Z = z;
            Type = tupleType;
        }
    }
}