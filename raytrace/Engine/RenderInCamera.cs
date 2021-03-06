namespace RayTrace.Engine
{
    using RayTrace.Models;
    using RayTrace.Transforms;

    public class RenderInCamera
    {
        public void CreateScene()
        {
            var floor = new Sphere()
            {
                Transform = Transformation.Scale(10,0.01,10),
                Material = new Material()
                {
                    Colour = new Colour(1, 0.9, 0.9),
                    Specular = 0
                }
            };
            var leftWall = new Sphere()
            {
                Transform = Transformation.Translation(0,0,5) * 
                            Transformation.RotateY(-(Math.PI/4)) * 
                            Transformation.RotateX(Math.PI/2) * 
                            Transformation.Scale(10, 0.01, 10),
                Material = floor.Material
            };
            var rightWall = new Sphere()
            {
                Transform = Transformation.Translation(0,0,5) *
                            Transformation.RotateY(Math.PI/4) *
                            Transformation.RotateX(Math.PI/2) * 
                            Transformation.Scale(10 , 0.01, 10),
                Material = floor.Material 
            };
            var middle = new Sphere()
            {
                Transform = Transformation.Translation(-0.5, 1, 0.5),
                Material = new Material()
                {
                    Colour = new Colour(0.1, 1, 0.5),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };
            var right = new Sphere()
            {
                Transform = Transformation.Translation(1.5, 0.5, -1.5) * 
                            Transformation.Scale( 0.5, 0.5, 0.5),
                Material = new Material()
                {
                    Colour = new Colour(0.5, 1, 0.1),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };
            var left = new Sphere()
            {
                Transform = Transformation.Translation(-1.5, 0.33, -0.75) * 
                            Transformation.Scale( 0.33, 0.33, 0.33),
                Material = new Material()
                {
                    Colour = new Colour(1, 0.8, 0.1),
                    Diffuse = 0.7,
                    Specular = 0.3
                }
            };
            var world = new World()
            {
                Light = new Light()
                {
                    Position = new Point(-10, 10, -10),
                    Intensity = new Colour(1, 1, 1)
                }
            };
            world.Add(floor);
            world.Add(leftWall);
            world.Add(rightWall);
            world.Add(left);
            world.Add(middle);
            world.Add(right);

            var camera = new Camera(500, 250, Math.PI/3)
            {
                Transform = ViewTransform.ViewTransformMatrix(
                    new Point(0,1.5,-5),
                    new Point(0,1,0),
                    new Vector(0,1,0))
            };
            var canvas = camera.Render(world);
            File.WriteAllText("RenderInCamera.ppm", canvas.ToPPM());
        }
    }
}
