using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjectsTest.Sources
{
    class Triangle_Intersects_HasIntersection_Source : Source<Triangle_Intersects_HasIntersection_Source.Args>
    {
        protected override string FileName => "Triangle-Intersection-Values.json";

        internal class Args
        {
            public Triangle? Triangle { get; set; }
            public Ray? Ray { get; set; }
            public double Expected { get; set; }
        }
    }
}