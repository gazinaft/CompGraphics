using System.Collections.Generic;

namespace GeometricObjects
{
    public class Mesh
    {
        public Mesh(IMaterial material)
        {
            Material = material;
        }
        public IMaterial Material { get; set; }

        private List<ITraceable> _traceables; 
        public List<ITraceable> Traceables
        {
            get => _traceables;
            set
            {
                foreach (ITraceable dTraceable in value)
                {
                    dTraceable.Material = Material;
                }
                _traceables = value;       
            }
        }

    }
}