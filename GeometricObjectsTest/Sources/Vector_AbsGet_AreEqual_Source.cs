using GeometricObjects.Basic;

namespace GeometricObjectsTest.Sources
{
    class Vector_AbsGet_AreEqual_Source : Source<Vector_AbsGet_AreEqual_Source.Args>
    {
        protected override string FileName => @"Vector-AbsGet-Values.json";

        internal class Args
        {
            public Vector? Vector { get; set; }
            public double Expected { get; set; }
        }
    }
}
