using System.Collections.Generic;
using GeometricObjects;
using GeometricObjects.Basic;

namespace Core
{
    public interface ICrossFinder
    {
        ITraceable ClosestCross(Ray r, List<ITraceable> traceables, out double t, out Vertex p);

        bool AnyCross(Ray r, List<ITraceable> traceables, out double t);

        bool AnyCrossExcept(Ray r, List<ITraceable> traceables, out double t, ITraceable exception);
    }
}