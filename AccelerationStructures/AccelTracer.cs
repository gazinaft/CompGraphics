using Core;
using GeometricObjects;
using GeometricObjects.Basic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace AccelerationStructures
{
    public class AccelTracer : ITracer
    {
        private readonly Camera camera;
        private readonly Color bgColor;
        private readonly IAccelStruct accelStruct;
        private readonly IShader _shader;
        private readonly List<ILighting> lights;

        public AccelTracer(Camera camera, Color bgColor, IAccelStruct accelStruct, List<ILighting> lights, IShader shader)
        {
            this.camera = camera;
            this.bgColor = bgColor;
            this.accelStruct = accelStruct;
            this.lights = lights;
            _shader = shader;
        }

        public Color[,] Trace(List<ITraceable> traceables)
        {
            accelStruct.Apply(traceables);
            var res = new Color[camera.ScaleX, camera.ScaleY];
            Parallel.For(0, camera.ScaleX * camera.ScaleY, xy =>
            {
                int x = xy / camera.ScaleY;
                int y = xy % camera.ScaleY;
                res[x, y] = Raycast(x, y, traceables);
            });

            return res;
        }

        private Color Raycast(int x, int y, List<ITraceable> traceables)
        {
            var ray = camera.GetRay(x, y);
            var closest = accelStruct.ClosestCross(ray, out _, out Vertex p);
            if (closest == null)
            {
                return bgColor;
            }

            var norm = closest.NormalAt(p);
            // return Color.FromArgb(clr, clr, clr);
            return _shader.Shade(p, norm, traceables, lights);
        }
    }
}
