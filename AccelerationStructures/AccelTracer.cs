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
        private readonly ICrossFinder accelStruct;
        private Scene _scene;

        public AccelTracer(Camera camera, Color bgColor, ICrossFinder accelStruct, Scene scene)
        {
            this.camera = camera;
            this.bgColor = bgColor;
            this.accelStruct = accelStruct;
            _scene = scene;
        }

        public Color[,] Trace()
        {
            accelStruct.Apply(_scene.Geometry.Value);
            var res = new Color[camera.ScaleX, camera.ScaleY];
            // Parallel.For(0, camera.ScaleX * camera.ScaleY, xy =>
            // {
            //     int x = xy / camera.ScaleY;
            //     int y = xy % camera.ScaleY;
            //     res[x, y] = Raycast(x, y);
            // });
            for (int xy = 0; xy < camera.ScaleX * camera.ScaleY; xy++)
            {
                int x = xy / camera.ScaleY;
                int y = xy % camera.ScaleY;
                res[x, y] = Raycast(x, y);
            }
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
            // return Color.FromArgb(clr, clr, clr);
            return closest.Material.BRDF(ray, p, norm, _scene);
        }
    }
}
