using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjectsTest.Sources
{
    class Sphere_Intersects_Inside_Source : Source<Sphere_Intersects_Inside_Source.Args>
    {
        protected override string FileName => @"Sphere-InsideIntersection-Values.json";

        internal class Args
        {
            public Sphere? Sphere { get; set; }
            public Ray? Ray { get; set; }
            public double Expected { get; set; }
        }
    }
}
