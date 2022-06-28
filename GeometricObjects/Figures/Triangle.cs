using System;

using GeometricObjects.Basic;

namespace GeometricObjects.Figures
{
    public class Triangle : ITraceable
    {
        public Vertex V0 { get; }
        public Vertex V1 { get; }
        public Vertex V2 { get; }
        private static readonly double EPSILON = 0.0000001;
        private BoundBox bounds;

        public Triangle(Vertex v0, Vertex v1, Vertex v2)
        {
            V0 = v0;
            V1 = v1;
            V2 = v2;
        }
        
        public bool Intersects(Ray ray, out double t)
        {
            t = 0.0;
            var edge1 = V1 - V0;
            var edge2 = V2 - V0;
            var h = ray.Direction * edge2;
            var det = edge1.Dot(h);
            if (det < EPSILON) { // only one sided triangles, because of culling
                return false;    // This ray is parallel to this triangle.
            }
            var f = 1.0 / det;
            var s = ray.Origin - V0;
            var u = f * s.Dot(h);
            if (u < 0.0 || u > 1.0) {
                return false;
            }
            var q = s * edge1;
            var v = f * ray.Direction.Dot(q);
            if (v < 0.0 || u + v > 1.0) {
                return false;
            }
            // At this stage we can compute t to find out where the intersection point is on the line.
            t = f * edge2.Dot(q); 
            return t > EPSILON;
        }

        public Vector NormalAt(Vertex p)
        {
            return ((V1 - V0) * (V2 - V0)).Normalize();
        }

        public BoundBox GetBounds()
        {
            if (bounds == null)
            {
                bounds = new(V0);
                bounds.Extend(V1);
                bounds.Extend(V2);
            }
            return bounds;
        }

        public IMaterial Material { get; set; }
    }
}
