using RayTrace.Models;

namespace RayTrace.Engine
{
    public class Environment
    {
        public Vector Gravity {get; set;}
        public Vector Wind {get; set;}
        public Environment(Vector gravity, Vector wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}