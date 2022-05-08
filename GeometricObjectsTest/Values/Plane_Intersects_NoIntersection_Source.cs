using System.Collections;

namespace GeometricObjectsTest.Values
{
    class Plane_Intersects_NoIntersection_Source : IEnumerable
    {
        private readonly Common common;

        public Plane_Intersects_NoIntersection_Source()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Plane1, common.Ray2 };
            yield return new object[] { common.Plane2, common.Ray2 };
        }
    }
}
