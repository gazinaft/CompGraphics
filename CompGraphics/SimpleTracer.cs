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

        private ITraceable ClosestCross(int x, int y, ITraceable[] traceables, out double t)
        {
            ITraceable closest = null;
            var minDistance = double.MaxValue;
            var ray = _camera.GetRay(x, y);
            foreach (var traceable in traceables)
            {
                if (traceable.Intersects(ray, out var tt))
                {
                    if (tt < minDistance)
                    {
                        minDistance = tt;
                        closest = traceable;
                    }
                }
            }

            t = minDistance;
            return closest;
        }

        private Color Raycast(int x, int y, ITraceable[] traceables)
        {
            var t = 0.0;
            var closest = ClosestCross(x, y, traceables, out t);

            return closest == null ? Color.Black : Color.White;
        }
        
        

        public Color[,] Trace(ITraceable[] traceables)
        {
            var res = new Color[_camera.Width, _camera.Height];
            for (int x = 0; x < _camera.Width; x++)
            {
                for (int y = 0; y < _camera.Height; y++)
                {
                    res[x, y] = Raycast(x, y, traceables);
                }
            }

            return res;
        }
    }
}