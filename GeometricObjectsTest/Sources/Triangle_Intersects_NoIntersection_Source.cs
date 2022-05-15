using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjectsTest.Sourses
{
    class Triangle_Intersects_NoIntersection_Source : Source<Triangle_Intersects_NoIntersection_Source.Args>
    {
        protected override string FileName => @"Triangle-NoIntersection-Values.json";

        internal class Args
        {
            public Triangle? Triangle { get; set; }
            public Ray? Ray { get; set; }
        }
    }
}