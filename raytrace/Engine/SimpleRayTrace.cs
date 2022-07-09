namespace RayTrace.Engine
{
    using RayTrace.Models;
    using RayTrace.Extensions;

    public class SimpleRayTrace
    {
        private Point rayOrigin;
        private double wall_z;
        private double wall_size;
        private int canvas_pixels;
        private double pixel_size;
        private double half;

        public SimpleRayTrace()
        {
            rayOrigin = new Point(0,0,-5);
            wall_z = 10;
            wall_size = 7;
            canvas_pixels = 100;
            pixel_size = wall_size/canvas_pixels;
            half = wall_size /2;
        }

        public void Cast()
        {
            var canvas = new Canvas(canvas_pixels,canvas_pixels);
            var colour = new Colour(1,0,0);
            var shape = new Sphere();
            shape.Material = new Material()
            {
                Colour = new Colour(1,0.2,1)
            };
            var light = new Light()
            {
                Position = new Point(-10,10,-10),
                Intensity = new Colour(1,1,1)
            };

            for(int y = 0; y < canvas_pixels; y++)
            {
                var world_y = half - pixel_size * y;

                for(int x = 0; x < canvas_pixels; x++)
                {
                    var world_x = -half + pixel_size * x;
                    var position = new Point(world_x, world_y, wall_z);

                    var ray = new Ray(rayOrigin, (position - rayOrigin).Normalise());

                    var intersects = shape.Intersect(ray);

                    if(intersects.Hit() != null)
                    {
                        var hit = intersects.Hit();
                        if( hit != null)
                        {
                            var point = ray.Position(hit.T);
                            var normal = ((Sphere)hit.Element).NormalAt(point);
                            var eye = !(ray.Direction as Vector);
                            var s = ((Sphere)hit.Element);
                            var c = s.Material.Lighting(light,point,eye,normal);

                            canvas.WritePixel(x,y,c);
                        }
                    }
                }
            }

            File.WriteAllText("SimpleRayTrace.ppm", canvas.ToPPM());
        }
    }
}