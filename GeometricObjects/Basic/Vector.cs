using System;

namespace GeometricObjects.Basic
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Abs => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector Normalize()
        {
            var abs = Abs;
            return new Vector(X / abs, Y / abs, Z / abs);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public double Dot(Vector v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector Scale(double ratio)
        {
            return new Vector(X * ratio, Y * ratio, Z * ratio);
        }
        public Vector Scale(double x, double y, double z)
        {
            return new Vector(X * x, Y * y, Z * z);
        }
        
        public override string ToString()
        {
            return $"Vector({X},{Y},{Z})";
        }
    }
}
