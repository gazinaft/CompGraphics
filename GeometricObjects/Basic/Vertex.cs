namespace GeometricObjects.Basic
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public static Vector operator -(Vertex p1, Vertex p2)
        {
            return new Vector(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
    }
}
