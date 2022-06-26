using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class SimpleTracer : ITracer
    {
        private Camera _camera;
        private ILighting _light;
        private ICrossFinder _crossFinder;
        private readonly Color _bgColor;
        private readonly IShader _shader;

        public SimpleTracer(Camera camera, ILighting light, ICrossFinder crossFinder, IShader shader, Color bgColor)
        {
            _camera = camera;
            _light = light;
            _crossFinder = crossFinder;
            _shader = shader;
            _bgColor = bgColor;
        }

        private ITraceable ClosestCross(int x, int y, List<ITraceable> traceables, out double t, out Vertex p)
        {
            var ray = _camera.GetRay(x, y);
            return _crossFinder.ClosestCross(ray, traceables, out t, out p);
        }

        private Color Raycast(int x, int y, List<ITraceable> traceables)
        {
            var t = 0.0;
            Vertex p = new Vertex(0, 0 , 0);
            var ray = _camera.GetRay(x, y);
            var closest = _crossFinder.ClosestCross(ray, traceables, out t, out p);
            if (closest == null)
            {
                return _bgColor;
            }
            
            var norm = closest.NormalAt(p);
            return _shader.Shade(p, norm, traceables, _light);
        }

        public Color[,] Trace(List<ITraceable> traceables)
        {
            var res = new Color[_camera.ScaleX, _camera.ScaleY];
            Parallel.For(0, _camera.ScaleX, x =>
            {
                for (int y = 0; y < _camera.ScaleY; y++)
                {
                    res[x, y] = Raycast(x, y, traceables);
                }
            });

            return res;
        }
        
    }
}