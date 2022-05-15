using GeometricObjects.Basic;

namespace GeometricObjectsTest.Sources
{
    class Plane_Intersects_HasIntersection_Source : Source<Plane_Intersects_HasIntersection_Source.Args>
    {
        protected override string FileName => @"Plane-Intersection-Values.json";

        internal class Args
        {
            public Plane? Plane { get; set; }
            public Ray? Ray { get; set; }
            public double Expected { get; set; }
        }
    }
}
