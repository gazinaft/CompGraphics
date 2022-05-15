using GeometricObjects.Basic;
using GeometricObjectsTest.Sources;
using NUnit.Framework;
using System;

namespace GeometricObjectsTest.Tests
{
    [TestFixture]
    class VectorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCaseSource(typeof(Vector_AbsGet_AreEqual_Source))]
        public void AbsGet_MultipleVectors_AreEqual(Vector vector, double expected)
        {
            double actual;

            actual = vector.Abs;

            Assert.AreEqual(expected, actual, Math.Pow(10, -12));
        }

        [TestCaseSource(typeof(Vector_Normalize_Normalized_Source))]
        public void Normalize_MultipleVectors_Normalized(Vector vector, Normal expected)
        {
            Vector actual; 
            
            actual = vector.Normalize();

            Assert.AreEqual(expected.X, actual.X, Math.Pow(10, -12));
            Assert.AreEqual(expected.Y, actual.Y, Math.Pow(10, -12));
            Assert.AreEqual(expected.Z, actual.Z, Math.Pow(10, -12));
        }
    }
}
