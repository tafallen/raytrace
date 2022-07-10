namespace RayTrace.Models
{
    using RayTrace.Extensions;
    public abstract class Spatial
    {
        public double Z { get; set; }
        public double Y { get; set; }
        public double X { get; set; }

        protected Spatial(double x, double y, double z) 
        {
            X = x;
            Y = y;
            Z = z;
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
        public bool Equals(Spatial other)
        {
            return (other.X.IsEqual(this.X) &&
                    other.Y.IsEqual(this.Y) &&
                    other.Z.IsEqual(this.Z));
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Y.GetHashCode();
        }
    }
}