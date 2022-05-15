using System.Collections;

namespace GeometricObjectsTest.Values
{
    class Plane_Intersects_Parallel_Source : IEnumerable
    {
        private readonly Common common;

        public Plane_Intersects_Parallel_Source()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Plane1, common.Ray5 };
            yield return new object[] { common.Plane3, common.Ray1 };
            yield return new object[] { common.Plane3, common.Ray2 };
        }
    }
}
