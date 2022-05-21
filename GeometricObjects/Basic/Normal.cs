namespace GeometricObjects.Basic
{
    //immutable btw
    public class Normal
    {
        private readonly double x;
        private readonly double y;
        private readonly double z;

        public Normal(Vector vector)
        {
            var norm = vector.Normalize();
            x = norm.X;
            y = norm.Y;
            z = norm.Z;
        }

        public double X => x;
        public double Y => y;
        public double Z => z;
    }
}
