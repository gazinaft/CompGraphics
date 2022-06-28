using GeometricObjects;
using GeometricObjects.Basic;
using System.Collections.Generic;
using Core;

namespace AccelerationStructures
{
    public interface IAccelStruct : ICrossFinder
    {
        void Apply(IEnumerable<ITraceable> traceables);
        ITraceable ClosestCross(Ray ray, out double t, out Vertex p);
        bool AnyCross(Ray ray);
    }
}
