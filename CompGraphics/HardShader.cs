using System;
using System.Collections.Generic;
using System.Drawing;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics
{
    public class HardShader : IShader
    {
        private ICrossFinder _crossFinder;
        private float _bias;

        public HardShader(ICrossFinder crossFinder, float bias)
        {
            _crossFinder = crossFinder;
            _bias = bias;
        }

        public Color Shade(Vertex v, Vector n, List<ITraceable> traceables, List<ILighting> ls)
        {
            var castPoint = v + n.Scale(_bias);
            var resLighting = Color.Black;
            foreach (ILighting l in ls)
            {
                var ray = l.ShadowRay(n, castPoint);
                var t = 0.0;
                if (_crossFinder.AnyCross(ray, traceables, out t))
                {
                    Console.WriteLine(ray.Direction + " " + ray.Origin);
                    Console.WriteLine(t);
                    continue;
                }

                resLighting = Coloristycs.Add(resLighting, l.OutLight(n, castPoint));
            }

            return resLighting;
        }
    }
}