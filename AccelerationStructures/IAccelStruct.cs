using GeometricObjects;
using GeometricObjects.Basic;
using System.Collections.Generic;

namespace AccelerationStructures
{
    public interface IAccelStruct
    {
        void Apply(IEnumerable<ITraceable> traceables);
        ITraceable ClosestCross(Ray ray, out double t, out Vertex p);
    }
}
