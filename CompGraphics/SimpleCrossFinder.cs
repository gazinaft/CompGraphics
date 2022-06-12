using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleCrossFinder : ICrossFinder
    {
        public ITraceable ClosestCross(Ray ray, ITraceable[] traceables, out double t, out Vertex p)
        {
            ITraceable closest = null;
            var minDistance = double.MaxValue;
            foreach (var traceable in traceables)
            {
                if (traceable.Intersects(ray, out var tt))
                {
                    if (tt < minDistance)
                    {
                        minDistance = tt;
                        closest = traceable;

                    }
                }
            }

            t = minDistance;
            p = ray.Origin + ray.Direction.Scale(t);
            return closest;
        }
    }
}