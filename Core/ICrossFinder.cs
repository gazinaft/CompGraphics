using GeometricObjects;
using GeometricObjects.Basic;

namespace Core
{
    public interface ICrossFinder
    {
        ITraceable ClosestCross(Ray r, ITraceable[] traceables, out double t, out Vertex p);
    }
}