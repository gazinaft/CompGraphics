using System.Collections.Generic;
using GeometricObjects;
using GeometricObjects.Basic;

namespace Core
{
    public interface ICrossFinder
    {
        void Apply(IEnumerable<ITraceable> traceables);
        ITraceable ClosestCross(Ray ray, out double t, out Vertex p);
        bool AnyCross(Ray ray);
    }
}