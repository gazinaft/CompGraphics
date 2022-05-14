using System.Collections;

namespace GeometricObjectsTest.Values
{
    public class Triangle_Intersects_NoIntersection : IEnumerable
    {
        private readonly Common common;

        public Triangle_Intersects_NoIntersection()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Triangle1, common.Ray4 }; // in the same plane as triangle 
            yield return new object[] { common.Triangle2, common.Ray4 }; // in the same plane as reversed triangle
            yield return new object[] { common.Triangle2, common.Ray4 };
            yield return new object[] { common.Triangle2, common.Ray4 };
        }
    }
}