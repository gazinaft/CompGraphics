using GeometricObjects.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricObjects.Advanced
{
    public static class VectorOperations
    {
        public static Vector Normalize(this Vector v)
        {
            var abs = Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
            return new Vector(v.x / abs, v.y / abs, v.z / abs);
        }

        public static Vector Sum(this Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector Sub(this Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector CrossProduct(this Vector v1, Vector v2)
        {
            return new Vector(v1.y * v2.z - v1.z * v2.y, v1.z * v2.x - v1.x * v2.z, v1.x * v2.y - v1.y * v2.x);
        }

        public static double DotProduct(this Vector v1, Vector v2)
        {
            return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }
    }
}
