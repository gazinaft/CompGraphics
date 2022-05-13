namespace GeometricObjects.Basic
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vertex()
        {

        }

        public Vertex(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator -(Vertex p1, Vertex p2)
        {
            return new Vector(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static Vertex operator +(Vertex p, Vector v)
        {
            return new Vertex(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }
    }
}
