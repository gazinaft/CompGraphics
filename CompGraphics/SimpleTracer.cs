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
        private ICrossFinder _crossFinder;
        private readonly Color _bgColor;

        public SimpleTracer(Camera camera, DirectionalLight light, ICrossFinder crossFinder, Color bgColor)
        {
            _camera = camera;
            _light = light;
            _crossFinder = crossFinder;
            _bgColor = bgColor;
        }

        private ITraceable ClosestCross(int x, int y, ITraceable[] traceables, out double t, out Vertex p)
        {
            var ray = _camera.GetRay(x, y);
            return _crossFinder.ClosestCross(ray, traceables, out t, out p);
        }

        private Color Raycast(int x, int y, ITraceable[] traceables)
        {
            var t = 0.0;
            Vertex p = new Vertex(0, 0 , 0);
            var closest = ClosestCross(x, y, traceables, out t, out p);
            if (closest == null)
            {
                return _bgColor;
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