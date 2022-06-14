using GeometricObjects.Basic;
using GeometricObjects.Figures;
using System.Collections.Generic;
using System.Linq;

namespace Matrix
{
    public static class Transformations
    {
        private static void Apply(Triangle obj, TransformationMatrix matrix)
        {
            matrix.ApplyTo(obj.V0);
            matrix.ApplyTo(obj.V1);
            matrix.ApplyTo(obj.V2);
        }

        private static void Apply(IEnumerable<Triangle> figure, TransformationMatrix matrix)
        {
            var vertices = figure.SelectMany(t => new Vertex[] { t.V0, t.V1, t.V2 }).Distinct();
            foreach (var vertex in vertices) matrix.ApplyTo(vertex);
        }

        #region Scale

        public static void Scale(Triangle obj, double multiplier)
        {
            Apply(obj, MatrixFor.Scaling(multiplier));
        }

        public static void Scale(IEnumerable<Triangle> figure, double multiplier)
        {
            Apply(figure, MatrixFor.Scaling(multiplier));
        }

        #endregion

        #region Rotate

        public static void Rotate(Triangle obj, Vector axis, double angle)
        {
            Apply(obj, MatrixFor.Rotation(axis, angle));
        }

        public static void Rotate(IEnumerable<Triangle> figure, Vector axis, double angle)
        {
            Apply(figure, MatrixFor.Rotation(axis, angle));
        }

        #endregion

        #region Transite

        public static void Transite(Triangle obj, double offsetX, double offsetY, double offsetZ)
        {
            Apply(obj, MatrixFor.Transition(offsetX, offsetY, offsetZ));
        }

        public static void Transite(IEnumerable<Triangle> figure, double offsetX, double offsetY, double offsetZ)
        {
            Apply(figure, MatrixFor.Transition(offsetX, offsetY, offsetZ));
        }

        #endregion
    }
}
