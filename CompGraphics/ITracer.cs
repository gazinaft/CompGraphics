using System.Drawing;
using GeometricObjects;

namespace CompGraphics
{
    public interface ITracer
    {
        public Color[,] Trace(ITraceable[] traceables);
    }
}