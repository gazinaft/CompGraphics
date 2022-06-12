using GeometricObjects;

namespace Core
{
    public interface IReader
    {
        ITraceable[] Read(string path);
    }
}
