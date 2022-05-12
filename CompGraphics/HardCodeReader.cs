using GeometricObjects;
using GeometricObjects.Figures;

namespace CompGraphics;

public class HardCodeReader : IReader
{
    public ITraceable[] Read(string path)
    {
        return new ITraceable[] { };
    }
}