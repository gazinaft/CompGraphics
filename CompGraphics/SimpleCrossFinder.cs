using System.Collections.Generic;
using System.Linq;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleCrossFinder : ICrossFinder
    {
        private List<ITraceable> traceables { get; set; }


        public void Apply(IEnumerable<ITraceable> traceables)
        {
            this.traceables = traceables.ToList();
        }

        public ITraceable ClosestCross(Ray ray, out double t, out Vertex p)
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

        public bool AnyCross(Ray r)
        {
            foreach (var traceable in traceables)
            {
                
                if (traceable.Intersects(r, out double t))
                {
                    return true;
                }
            } 
            return false;
        }
    }
}