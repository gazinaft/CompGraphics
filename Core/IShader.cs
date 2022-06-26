using System.Collections.Generic;
using System.Drawing;
using GeometricObjects;
using GeometricObjects.Basic;

namespace Core
{
    public interface IShader
    {
        Color Shade(Vertex v, Vector n, List<ITraceable> traceables, ILighting l);
    }
}