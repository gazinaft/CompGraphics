using GeometricObjects;
using GeometricObjects.Basic;
using System.Collections.Generic;

namespace ObjReader
{
    class ObjPool
    {
        public List<Vertex> Vertices { get; private set; } = new();
        public List<Normal> Normals { get; private set; } = new();
        public List<ITraceable> Traceables { get; private set; } = new();

        public ITraceable[] GetTraceables()
        {
            return Traceables.ToArray();
        }
    }
}
