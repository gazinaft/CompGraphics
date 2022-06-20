using System;
using System.Collections.Generic;
using System.Drawing;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics;

public class HardShader: IShader
{
    private ICrossFinder _crossFinder;
    private float _bias;
    
    public HardShader(ICrossFinder crossFinder, float bias)
    {
        _crossFinder = crossFinder;
        _bias = bias;
    }

    public Color Shade(Vertex v, Vector n, List<ITraceable> traceables, DirectionalLight l)
    {
        var castPoint = v + n.Scale(_bias);
        var ray = new Ray() { Origin = castPoint, Direction = l.Direction };
        var t = 0.0;
        var dot = Math.Max(l.Direction.Dot(n), 0.0);
        if (dot > 0.0 && _crossFinder.AnyCross(ray, traceables, out t))
        {
            Console.WriteLine(ray.Direction + " " + ray.Origin);
            Console.WriteLine(t);
            return Color.Black;
        }
        var lighting = (int)Math.Ceiling(255 * dot);
        return Color.FromArgb(lighting, lighting, lighting);
    }
}