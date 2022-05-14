using GeometricObjects.Basic;
using System;

namespace GeometricObjects.Figures
{
    public class Sphere : ITraceable
    {
        public Vertex Center { get; set; }
        public double Radius { get; set; }

        public bool Intersects(Ray ray, out double t)
        {
            //(o + dt - c)^2 = r^2
            //(dt + k)^2 = r^2
            //t^2 + 2dk*t + (k^2 - r^2) = 0
            //b/2 = dk; a = 1, c = k^2 - r^2
            //D = 4 * ((b/2)^2 - k^2 + r^2)
            //t1 = -b/2 - sD/2; t2 = -b/2 + sD/2;
            //t1 < t2
            t = 0;
            var k = ray.Origin - Center;
            var b2 = ray.Direction.Dot(k);
            var ka = k.Abs;
            var D = (b2 * b2 + Radius * Radius - ka * ka) * 4;
            if (D < 0) return false;
            var sD = Math.Sqrt(D);
            var t1 = -b2 - sD/2;
            var t2 = -b2 + sD/2;
            if (t1 < 0 && t2 < 0) return false;
            t = t1 < 0 ? t2 : t1;
            return true;
        }

        public Vector NormalAt(Vertex p)
        {
            return (p - Center).Normalize();
        }
    }
}
