using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjectsTest.Sources
{
    class Sphere_Intersects_NoIntersection_Source : Source<Sphere_Intersects_NoIntersection_Source.Args>
    {
        protected override string FileName => @"Sphere-NoIntersection-Values.json";

        internal class Args
        {
            public Sphere? Sphere { get; set; }
            public Ray? Ray { get; set; }
        }
    }
}
