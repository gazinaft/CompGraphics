using System.Collections;

namespace GeometricObjectsTest.Values
{
    class Vector_Normalize_Normalized_Source : IEnumerable
    {
        private readonly Common common;

        public Vector_Normalize_Normalized_Source()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Vector1, common.Normal1 };
            yield return new object[] { common.Vector2, common.Normal2 };
            yield return new object[] { common.Vector3, common.Normal3 };
            yield return new object[] { common.Vector4, common.Normal4 };
        }
    }
}
