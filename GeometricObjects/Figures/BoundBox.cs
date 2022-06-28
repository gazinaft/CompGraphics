using GeometricObjects.Basic;
using System;

namespace GeometricObjects.Figures
{
    public class BoundBox
    {
        public Vertex Max { get; set; } = new(double.MaxValue, double.MaxValue, double.MaxValue);
        public Vertex Min { get; set; } = new(double.MinValue, double.MinValue, double.MinValue);

        public BoundBox()
        {
            //if creating with parameterless ctor then bounds will catch the whole world
            //(for figures with infinite bounds)
        }

        public BoundBox(Vertex v)
        {
            Min.X = v.X;
            Min.Y = v.Y;
            Min.Z = v.Z;

            Max.X = v.X;
            Max.Y = v.Y;
            Max.Z = v.Z;
        }

        public BoundBox(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            Min.X = minX;
            Min.Y = minY;
            Min.Z = minZ;

            Max.X = maxX;
            Max.Y = maxY;
            Max.Z = maxZ;
        }

        public (double, double, double) Center()
        {
            var x = (Min.X + Max.X) / 2;
            var y = (Min.Y + Max.Y) / 2;
            var z = (Min.Z + Max.Z) / 2;
            return (x, y, z);
        }

        public void Extend(Vertex v)
        {
            Min.X = Math.Min(Min.X, v.X);
            Min.Y = Math.Min(Min.Y, v.Y);
            Min.Z = Math.Min(Min.Z, v.Z);

            Max.X = Math.Max(Max.X, v.X);
            Max.Y = Math.Max(Max.Y, v.Y);
            Max.Z = Math.Max(Max.Z, v.Z);
        }

        public bool Intersects(Ray ray, out double t)
        {
            t = 0;
            Vector inv = InvertDirection(ray.Direction);

            double tmin = (Min.X - ray.Origin.X) * inv.X;
            double tmax = (Max.X - ray.Origin.X) * inv.X;
            if (inv.X < 0) (tmin, tmax) = (tmax, tmin);

            double tymin = (Min.Y - ray.Origin.Y) * inv.Y;
            double tymax = (Max.Y - ray.Origin.Y) * inv.Y;
            if (inv.Y < 0) (tymin, tymax) = (tymax, tymin);

            if ((tmin > tymax) || (tymin > tmax)) return false;

            tmin = Math.Max(tmin, tymin);
            tmax = Math.Min(tmax, tymax);

            double tzmin = (Min.Z - ray.Origin.Z) * inv.Z;
            double tzmax = (Max.Z - ray.Origin.Z) * inv.Z;
            if (inv.Z < 0) (tzmin, tzmax) = (tzmax, tzmin);

            if ((tmin > tzmax) || (tzmin > tmax)) return false;

            tmin = Math.Max(tmin, tzmin);
            tmax = Math.Min(tmax, tzmax);

            t = Math.Min(tmin, tmax);
            return true;
        }

        private Vector InvertDirection(Vector direction)
        {
            // TODO test zero division
            var x = 1 / direction.X;
            var y = 1 / direction.Y;
            var z = 1 / direction.Z;
            return new(x, y, z);
        }
    }
}
