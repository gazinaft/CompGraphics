using System.Collections.Generic;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleCrossFinder : ICrossFinder
    {
        public ITraceable ClosestCross(Ray ray, List<ITraceable> traceables, out double t, out Vertex p)
        {
            ITraceable closest = null;
            var minDistance = double.MaxValue;
            foreach (var traceable in traceables)
            {
                var tt = 0.0;
                if (traceable.Intersects(ray, out tt))
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

        public bool AnyCross(Ray r, List<ITraceable> traceables, out double t)
        {
            foreach (var traceable in traceables)
            {
                if (traceable.Intersects(r, out t))
                {
                    return true;
                }
            }

            t = 0;
            return false;
        }

        public bool AnyCrossExcept(Ray r, List<ITraceable> traceables, out double t, ITraceable exception)
        {
            foreach (var traceable in traceables)
            {
                if (traceable == exception)
                {
                    continue;
                }
                if (traceable.Intersects(r, out t))
                {
                    return true;
                }
            }

            t = 0;
            return false;
        }
    }
}