using GeometricObjects.Basic;
using System;

namespace Matrix
{
    public class MatrixFor
    {
        public static TransformationMatrix Scaling(double multiplier)
        {
            TransformationMatrix matrix = new();
            matrix.Source[0, 0] = multiplier;
            matrix.Source[1, 1] = multiplier;
            matrix.Source[2, 2] = multiplier;
            matrix.Source[3, 3] = 1;
            return matrix;
        }

        public static TransformationMatrix Rotation(Vector axis, double radians)
        {
            TransformationMatrix matrix = new();
            Vector unit = axis.Normalize();
            var cos = Math.Cos(radians);
            var sin = Math.Sin(radians);
            var l = unit.X;
            var m = unit.Y;
            var n = unit.Z;

            matrix.Source[0, 0] = l * l * (1 - cos) + 1 * cos;
            matrix.Source[0, 1] = m * l * (1 - cos) - n * sin;
            matrix.Source[0, 2] = n * l * (1 - cos) + m * sin;
            matrix.Source[1, 0] = l * m * (1 - cos) + n * sin;
            matrix.Source[1, 1] = m * m * (1 - cos) + 1 * cos;
            matrix.Source[1, 2] = n * m * (1 - cos) - l * sin;
            matrix.Source[2, 0] = l * n * (1 - cos) - m * sin;
            matrix.Source[2, 1] = m * n * (1 - cos) + l * sin;
            matrix.Source[2, 2] = n * n * (1 - cos) + 1 * cos;
            matrix.Source[3, 3] = 1;

            return matrix;
        }

        public static TransformationMatrix Transition(double offsetX, double offsetY, double offsetZ)
        {
            TransformationMatrix matrix = new();

            matrix.Source[0, 0] = 1;
            matrix.Source[1, 1] = 1;
            matrix.Source[2, 2] = 1;
            matrix.Source[3, 3] = 1;
            matrix.Source[3, 0] = offsetX;
            matrix.Source[3, 1] = offsetY;
            matrix.Source[3, 2] = offsetZ;

            return matrix;
        }
    }
}
