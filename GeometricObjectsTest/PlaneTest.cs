using GeometricObjects.Basic;
using GeometricObjectsTest.Values;
using NUnit.Framework;
using System;

namespace GeometricObjectsTest
{
    [TestFixture]
    public class PlaneTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCaseSource(typeof(Plane_Intersects_HasIntersection_Source))]
        public void Intersects_MultipleValues_HasIntersection(Plane plane, Ray ray, double expected)
        {
            bool intersects;

            intersects = plane.Intersects(ray, out double actual);

            Assert.IsTrue(intersects);
            Assert.GreaterOrEqual(actual, 0);
            Assert.AreEqual(expected, actual, Math.Pow(10, -12));
        }

        [TestCaseSource(typeof(Plane_Intersects_NoIntersection_Source))]
        public void Intersects_MultipleValues_NoIntersection(Plane plane, Ray ray)
        {
            bool intersects;

            intersects = plane.Intersects(ray, out double actual_t);

            Assert.IsFalse(intersects);
            Assert.Less(actual_t, 0);
        }

        [TestCaseSource(typeof(Plane_Intersects_Parallel_Source))]
        public void Intersects_MultipleValues_Parallel(Plane plane, Ray ray)
        {
            bool intersects;

            intersects = plane.Intersects(ray, out double actual);

            Assert.IsFalse(intersects);
            Assert.AreEqual(0, actual);
        }
    }
}
