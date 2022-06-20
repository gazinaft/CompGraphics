using System.Collections.Generic;
using GeometricObjects;

namespace Core
{
    public interface IReader
    {
        List<ITraceable> Read(string path);
    }
}
