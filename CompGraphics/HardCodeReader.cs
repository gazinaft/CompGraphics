using System.Collections.Generic;
using GeometricObjects;
using GeometricObjects.Figures;

namespace CompGraphics;

public class HardCodeReader : IReader
{
    private List<ITraceable> _traceables = new List<ITraceable>();
    
    public ITraceable[] Read(string path)
    {
        return _traceables.ToArray();
    }

    public HardCodeReader Add(ITraceable obj)
    {
        _traceables.Add(obj);
        return this;
    }
}