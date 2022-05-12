using System.Drawing;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleTracer : ITracer
    {
        private Camera _camera;

        public SimpleTracer(Camera camera)
        {
            _camera = camera;
        }

        public ITraceable TracePixel()
        {
            throw new System.NotImplementedException();
        }

        public Color[,] Trace(ITraceable[] traceables)
        {
            throw new System.NotImplementedException();
        }
    }
}