using System.Collections.Generic;
using GeometricObjects;

namespace Core
{
    public class Model
    {
        public IMaterial Material { get; set; }
        public List<ITraceable> Traceables { get; set; }
    }
}