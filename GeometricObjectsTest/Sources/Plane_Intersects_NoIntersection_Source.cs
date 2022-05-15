using GeometricObjects.Basic;

namespace GeometricObjectsTest.Sources
{
    class Plane_Intersects_NoIntersection_Source : Source<Plane_Intersects_NoIntersection_Source.Args>
    {
        protected override string FileName => @"Plane-NoIntersection-Values.json";

        internal class Args
        {
            public Plane? Plane { get; set; }
            public Ray? Ray { get; set; }
        }
    }
}
