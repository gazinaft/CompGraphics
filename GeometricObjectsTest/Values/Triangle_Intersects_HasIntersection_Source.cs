using System.Collections;

namespace GeometricObjectsTest.Values
{
    public class Triangle_Intersects_HasIntersection : IEnumerable
    {
        private readonly Common common;

        public Triangle_Intersects_HasIntersection()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Triangle1, common.Ray5 };
            
        }
    }
}