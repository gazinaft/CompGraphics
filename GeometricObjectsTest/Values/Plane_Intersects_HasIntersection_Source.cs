using System.Collections;

namespace GeometricObjectsTest.Values
{
    class Plane_Intersects_HasIntersection_Source : IEnumerable
    {
        private readonly Common common;

        public Plane_Intersects_HasIntersection_Source()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Plane1, common.Ray1, 10 };
            yield return new object[] { common.Plane1, common.Ray3, 13 };
            yield return new object[] { common.Plane2, common.Ray1, 19 };
            yield return new object[] { common.Plane2, common.Ray4, System.Math.Sqrt(27) };
        }
    }
}
