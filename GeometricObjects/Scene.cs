using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometricObjects
{
    public class Scene
    {
        public List<Mesh> Meshes { get; set; }
        public List<ILighting> Lights { get; set; }

        public Lazy<List<ITraceable>> Geometry
        {
            get => new Lazy<List<ITraceable>>(Meshes.SelectMany(x => x.Traceables).ToList());
        } 
    }
}