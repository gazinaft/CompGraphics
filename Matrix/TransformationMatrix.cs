using GeometricObjects.Basic;

namespace Matrix
{
    public class TransformationMatrix : Matrix4x4
    {
        public void ApplyTo(Vertex vertex)
        {
            double[] vector4 = new double[] { vertex.X, vertex.Y, vertex.Z, 1 };
            double[] result = MultiplyBy(vector4);
            vertex.X = result[0];
            vertex.Y = result[1];
            vertex.Z = result[2];
            vertex.Normal = ApplyTo(vertex.Normal);
        }

        public void ApplyTo(Vector vector)
        {
            double[] vector4 = new double[] { vector.X, vector.Y, vector.Z, 1 };
            double[] result = MultiplyBy(vector4);
            vector.X = result[0];
            vector.Y = result[1];
            vector.Z = result[2];
        }

        public Normal ApplyTo(Normal normal)
        {
            double[] vector4 = new double[] { normal.X, normal.Y, normal.Z, 1 };
            double[] result = MultiplyBy(vector4);
            return new(new(result[0], result[1], result[2]));
        }
    }
}