using RayTrace.Extensions;
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

    public class CannonEngine
    {
        public Projectile Projectile {get; set;}
        public Environment Env {get; set;}
        public CannonEngine(Projectile projectile, Environment environment )
        {
            Projectile = projectile;
            Env = environment;
        }

        public Projectile Tick()
        {
            var position = Projectile.Position + Projectile.Velocity;
            var velocity = Projectile.Velocity + Env.Gravity + Env.Wind;
            return new Projectile(position, velocity);
        }

        public static void FireCannon()
        {
            var projectile = new Projectile(
                RayTuple.Point(0,1,0),
                RayTuple.Vector(1,1,0).Normalise());
            var environment = new RayTrace.Engine.Environment(
                RayTuple.Vector(0,-0.1,0),
                RayTuple.Vector(-0.01,0,0));
            var engine = new CannonEngine(projectile,environment);   

            while(engine.Projectile.Position.Y > 0)
            {
                Console.WriteLine("Pos: " + engine.Projectile.Position + " V: " + engine.Projectile.Velocity);
                engine.Projectile = engine.Tick();
            }
            Console.WriteLine("Pos: " + engine.Projectile.Position + " V: " + engine.Projectile.Velocity);
        }
    }
}