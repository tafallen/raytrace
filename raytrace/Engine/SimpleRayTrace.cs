namespace RayTrace.Engine
{
    using RayTrace.Models;
    using RayTrace.Extensions;
    using RayTrace.Transforms;

    public class SimpleRayTrace
    {
        private RayTuple rayOrigin;
        private double wall_z;
        private double wall_size;
        private int canvas_pixels;
        private double pixel_size;
        private double half;

        public SimpleRayTrace()
        {
            rayOrigin = RayTuple.Point(0,0,-5);
            wall_z = 10;
            wall_size = 7;
            canvas_pixels = 1000;
            pixel_size = wall_size/canvas_pixels;
            half = wall_size /2;
        }

        public void Cast()
        {
            var canvas = new Canvas(canvas_pixels,canvas_pixels);
            var colour = new Colour(1,0,0);
            var shape = new Sphere();

            for(int y = 0; y < canvas_pixels; y++)
            {
                var world_y = half - pixel_size * y;

                for(int x = 0; x < canvas_pixels; x++)
                {
                    var world_x = -half + pixel_size * x;
                    var position = RayTuple.Point(world_x, world_y, wall_z);
                    var ray = new Ray(rayOrigin, (position -rayOrigin).Normalise());
                    Intersections intersects = shape.Intersect(ray);

                    if(Intersections.List.Hit() != null)
                    {
                        canvas.WritePixel(x,y,colour);
                    }
                    Intersections.List.Clear();
                }
            }

            File.WriteAllText("SimpleRayTrace.ppm", canvas.ToPPM());
        }
    }
}