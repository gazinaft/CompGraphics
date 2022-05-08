using System;
using System.Collections;

namespace GeometricObjectsTest.Values
{
    class Vector_AbsGet_AreEqual_Source : IEnumerable
    {
        private readonly Common common;

        public Vector_AbsGet_AreEqual_Source()
        {
            common = new();
        }

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { common.Vector1, 4 };
            yield return new object[] { common.Vector2, 13 };
            yield return new object[] { common.Vector3, Math.Sqrt(3) };
            yield return new object[] { common.Vector4, Math.Sqrt(2) };
        }
    }
}
