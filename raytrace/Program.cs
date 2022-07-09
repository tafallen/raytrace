using System.Diagnostics;
//RayTrace.Engine.CannonEngine.FireCannon();

// var simpleRayTrace = new RayTrace.Engine.SimpleRayTrace();
// simpleRayTrace.Cast();

var stopwatch = new Stopwatch();

stopwatch.Start();
var renderInCamera = new RayTrace.Engine.RenderInCamera();
renderInCamera.CreateScene();
stopwatch.Stop();

Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");