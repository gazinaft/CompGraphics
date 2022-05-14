using System;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using GeometricObjectsTest.Values;
using NUnit.Framework;

namespace GeometricObjectsTest
{
    [TestFixture]
    public class TriangleTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCaseSource(typeof(Triangle_Intersects_HasIntersection))]
        public void Intersects_MultipleValues_HasIntersection(Triangle triangle, Ray ray, double expected)
        {
            bool intersects;

            intersects = triangle.Intersects(ray, out double actual);

            Assert.IsTrue(intersects);
            Assert.GreaterOrEqual(actual, 0);
            Assert.AreEqual(expected, actual, Math.Pow(10, -12));
        }

        [TestCaseSource(typeof(Triangle_Intersects_NoIntersection))]
        public void Intersects_MultipleValues_NoIntersection(Triangle triangle, Ray ray, double expected)
        {
            bool intersects;

            intersects = triangle.Intersects(ray, out double actual_t);

            Assert.IsFalse(intersects);
            Assert.LessOrEqual(actual_t, 0);
        }
    }
}