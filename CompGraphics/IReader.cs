using GeometricObjects;

namespace CompGraphics
{
    public interface IReader
    {
        ITraceable[] Read(string path);
    }
}