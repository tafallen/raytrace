namespace RayTrace.Models{
    public class RayTuple
    {
        public RayTuple(double x = 0.0, double y =0.0, double z=0.0, RayTupleType tupleType = RayTupleType.Point)
        {
            X = x;
            Y = y;
            Z = z;
            Type = tupleType;
        }
        public RayTupleType Type { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public override bool Equals(object? obj)
        {
            if( base.Equals(obj) )
                return true;
            else if( obj == null )
                return false;
            else
                return Equals((RayTuple)obj); 
        }

        public bool Equals(RayTuple other)
        {
            return (other.X == this.X &&
                    other.Y == this.Y &&
                    other.Z == this.Z &&
                    other.Type == this.Type);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + 
                    Y.GetHashCode() + 
                    Z.GetHashCode() + 
                    Type.GetHashCode();
        }
    }
}