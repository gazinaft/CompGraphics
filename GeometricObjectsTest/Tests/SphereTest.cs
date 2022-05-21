using GeometricObjects.Basic;
using GeometricObjects.Figures;
using GeometricObjectsTest.Sources;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjectsTest.Tests
{
    [TestFixture]
    class SphereTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCaseSource(typeof(Sphere_Intersects_Outside_Source))]
        public void Intersects_FromOutside_HasIntersection(Sphere sphere, Ray ray, double expected)
        {
            bool intersects;

            intersects = sphere.Intersects(ray, out double actual);

            Assert.IsTrue(intersects);
            Assert.Greater(actual, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Sphere_Intersects_Inside_Source))]
        public void Intersects_FromInside_HasIntersection(Sphere sphere, Ray ray, double expected)
        {
            bool intersects;

            intersects = sphere.Intersects(ray, out double actual);

            Assert.IsTrue(intersects);
            Assert.Greater(actual, 0);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Sphere_Intersects_NoIntersection_Source))]
        public void Intersects_MultipleValues_NoIntersection(Sphere sphere, Ray ray)
        {
            bool intersects;

            intersects = sphere.Intersects(ray, out double actual);

            Assert.IsFalse(intersects);
            Assert.AreEqual(0, actual);
        }
    }
}
