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
        private readonly DirectionalLight light;

        public AccelTracer(Camera camera, Color bgColor, IAccelStruct accelStruct, DirectionalLight light)
        {
            this.camera = camera;
            this.bgColor = bgColor;
            this.accelStruct = accelStruct;
            this.light = light;
        }

        public Color[,] Trace(List<ITraceable> traceables)
        {
            accelStruct.Apply(traceables);
            var res = new Color[camera.ScaleX, camera.ScaleY];
            Parallel.For(0, camera.ScaleX * camera.ScaleY, xy =>
            {
                int x = xy / camera.ScaleY;
                int y = xy % camera.ScaleY;
                res[x, y] = Raycast(x, y);
            });

            return res;
        }

        private Color Raycast(int x, int y)
        {
            var ray = camera.GetRay(x, y);
            var closest = accelStruct.ClosestCross(ray, out _, out Vertex p);
            if (closest == null)
            {
                return bgColor;
            }

            var norm = closest.NormalAt(p);
            var clr = (int)Math.Ceiling(255 * Math.Max(light.Direction.Dot(norm), 0));
            return Color.FromArgb(clr, clr, clr);
            //return _shader.Shade(p, norm, traceables, _light);
        }
    }
}
