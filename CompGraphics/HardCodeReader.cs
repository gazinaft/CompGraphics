using System.Collections.Generic;
using Core;
using GeometricObjects;
using GeometricObjects.Figures;

namespace CompGraphics
{
    public class HardCodeReader : IReader
    {
        private List<ITraceable> _traceables = new List<ITraceable>();

        public List<ITraceable> Read(string path)
        {
            return _traceables;
        }

        public HardCodeReader Add(ITraceable obj)
        {
            _traceables.Add(obj);
            return this;
        }
    }
}