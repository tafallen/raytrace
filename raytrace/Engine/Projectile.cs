using RayTrace.Models;

namespace RayTrace.Engine
{
    public class Projectile
    {
        public RayTuple Position {get; set;}
        public RayTuple Velocity {get; set;}
        public Projectile(RayTuple position, RayTuple velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}