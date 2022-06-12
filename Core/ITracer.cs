using System.Drawing;
using GeometricObjects;

namespace Core
{
    public interface ITracer
    {
        public Color[,] Trace(ITraceable[] traceables);
    }
}