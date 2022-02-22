namespace GeometricObjects.Basic
{
    public struct Point
    {
        public double x;
        public double y;
        public double z;

        public static Vector operator -(Point p1, Point p2)
        {
            return new Vector(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }
    }
}
