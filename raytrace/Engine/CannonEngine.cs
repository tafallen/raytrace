using RayTrace.Extensions;
using RayTrace.Models;

namespace RayTrace.Engine
{
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
                (RayTuple.Vector(1,1.8,0).Normalise())*11.25);
            var environment = new RayTrace.Engine.Environment(
                RayTuple.Vector(0,-0.1,0),
                RayTuple.Vector(-0.01,0,0));
            var engine = new CannonEngine(projectile,environment);   

            var canvas = new Canvas(900,550);

            while(engine.Projectile.Position.Y > 0)
            {
                Console.WriteLine($"Pos: {(int)engine.Projectile.Position.X},{(int)engine.Projectile.Position.Y} V: {engine.Projectile.Velocity}");
                canvas.WritePixel(((int)engine.Projectile.Position.X), (int)engine.Projectile.Position.Y, new Colour(1,0,0));
                engine.Projectile = engine.Tick();
            }
            Console.WriteLine($"Pos: {(int)engine.Projectile.Position.X},{(int)engine.Projectile.Position.Y} V: {engine.Projectile.Velocity}");
            File.WriteAllText("image.ppm", canvas.ToPPM());
        }
    }
}