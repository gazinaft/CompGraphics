namespace Matrix
{
    public class Matrix4x4
    {
        private readonly double[,] source = new double[4, 4];

        public Matrix4x4()
        {

        }

        public double[,] Source => source;

        public double[] MultiplyBy(double[] vector4)
        {
            double[] result = new double[] { 0, 0, 0, 0 };
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < vector4.Length; j++)
                {
                    result[i] += source[i, j] * vector4[j];
                }
            }

            return result;
        }
    }
}
