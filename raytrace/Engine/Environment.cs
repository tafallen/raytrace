using RayTrace.Models;

namespace RayTrace.Engine
{
    public class Environment
    {
        public RayTuple Gravity {get; set;}
        public RayTuple Wind {get; set;}
        public Environment(RayTuple gravity, RayTuple wind)
        {
            Gravity = gravity;
            Wind = wind;
        }
    }
}