using GeometricObjects.Basic;

namespace GeometricObjectsTest.Sources
{
    class Plane_Intersects_Parallel_Source : Source<Plane_Intersects_Parallel_Source.Args>
    {
        protected override string FileName => @"Plane-Parallel-Values.json";

        internal class Args
        {
            public Plane? Plane { get; set; }
            public Ray? Ray { get; set; }
        }
    }
}
