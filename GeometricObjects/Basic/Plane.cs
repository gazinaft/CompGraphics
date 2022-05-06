namespace GeometricObjects.Basic
{
    public class Plane : ITraceable
    {
        public Vector Normal { get; set; }
        public Vertex Point { get; set; }

        public bool Intersects(Ray ray, out HitResult hr)
        {
            hr = new HitResult(0);
            //normal.dot(ray.dir) = 0
            var scalar = Normal.Dot(ray.Direction);
            if (scalar == 0) return false;
            /*
             * x = x1 + at
             * y = y1 + bt
             * z = z1 + ct
             * 
             * Ax + By + Cz + D = 0
             * D = - (Ax2 + By2 + Cz2)
             * 
             * A(x1 + at) + B(y1 + bt) + C(z1 + ct) + D = 0
             * Aat + Bbt + Cct + Ax1 + By1 + Cz1 - (Ax2 + By2 + Cz2) = 0
             * t = (Ax2 + By2 + Cz2 - Ax1 - By1 - Cz1)/(Aa + Bb + Cc)
             *   = (A(x2 - x1) + B(y2 - y1) + C(z2 - z1))/scalar
             * **/
            hr.t = Normal.Dot(Point - ray.Origin) / scalar;
            return hr.t >= 0;
        }
    }
}
