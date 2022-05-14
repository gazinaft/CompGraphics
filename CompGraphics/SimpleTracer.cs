using System;
using System.Drawing;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleTracer : ITracer
    {
        private Camera _camera;
        private DirectionalLight _light;
        private Color BgColor { get; }

        public SimpleTracer(Camera camera, DirectionalLight light, Color bgColor)
        {
            _camera = camera;
            _light = light;
            BgColor = bgColor;
        }

        private ITraceable ClosestCross(int x, int y, ITraceable[] traceables, out double t, out Vertex p)
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
            p = ray.Origin + ray.Direction.Scale(t);
            return closest;
        }

        private Color Raycast(int x, int y, ITraceable[] traceables)
        {
            var t = 0.0;
            Vertex p = new Vertex(0, 0 , 0);
            var closest = ClosestCross(x, y, traceables, out t, out p);
            if (closest == null)
            {
                return BgColor;
            }
            var norm = closest.NormalAt(p);
            var dot = Math.Max(_light.Direction.Dot(norm), 0.0);
            var lighting = (int)Math.Ceiling(255 * dot);
            return Color.FromArgb(lighting, lighting, lighting);
        }
        
        

        public Color[,] Trace(ITraceable[] traceables)
        {
            var res = new Color[_camera.ScaleX, _camera.ScaleY];
            for (int x = 0; x < _camera.ScaleX; x++)
            {
                for (int y = 0; y < _camera.ScaleY; y++)
                {
                    res[x, y] = Raycast(x, y, traceables);
                }
            }

            return res;
        }
    }
}