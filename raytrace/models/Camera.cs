namespace RayTrace.Models
{
    using RayTrace.Extensions;
    using RayTrace.Transforms;
    public class Camera
    {
        public int Hsize {get;set;}
        public int Vsize {get;set;}
        public double FieldOfView {get;set;}
        public double HalfWidth {get;set;}
        public double HalfHeight {get;set;}
        public BasicTransform Transform {get;set;}
        public double PixelSize
        {
            get
            {
                var halfView = Math.Tan(FieldOfView/2);
                var aspect = (double)Hsize / (double)Vsize;
                if(aspect>=1)
                {
                    HalfWidth = halfView;
                    HalfHeight = halfView/aspect;
                }
                else
                {
                    HalfWidth = halfView * aspect;
                    HalfHeight = halfView;
                }
                return (HalfWidth*2)/Hsize;
            }
        }
        public Camera(int hsize=160, int vsize=120, double fieldOfView = Math.PI/2)
        {
            Hsize = hsize;
            Vsize = vsize;
            FieldOfView = fieldOfView;
            Transform = new CompoundTransform(){ Matrix = Matrix.IdentityMatrix };
        }
        public Ray RayForPixel(int px, int py)
        {
            var xoffset = (px + 0.5) * PixelSize;
            var yoffset = (py + 0.5) * PixelSize;

            var worldX = HalfWidth - xoffset;
            var worldY = HalfHeight - yoffset;

            var inverseTransform = Transform.Inverse(); 
            var pixel = inverseTransform.Matrix * new Point(worldX, worldY, -1);
            var origin = inverseTransform.Matrix * new Point(0,0,0);
            var direction = (pixel - origin).Normalise();

            return new Ray(origin, direction);
        }
        public Canvas Render(World world)
        {
            var image = new Canvas(Hsize, Vsize);

            Parallel.For(0, Vsize, y=>{
                Parallel.For(0, Hsize, x=>{
                    var ray = RayForPixel(x,y);
                    var colour = world.ColourAt(ray);
                    image.WritePixel(x,y,colour); 
                });
            });
            return image;
        }
    }
}