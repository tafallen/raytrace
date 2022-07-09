using System.Diagnostics;
//RayTrace.Engine.CannonEngine.FireCannon();

var stopwatch = new Stopwatch();

stopwatch.Start();
var simpleRayTrace = new RayTrace.Engine.SimpleRayTrace();
simpleRayTrace.Cast();
stopwatch.Stop();

Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}");