using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace GeometricObjectsTest.Values
{
    class Common
    {
        public Normal Normal1 => new(Vector1);
        public Normal Normal2 => new(Vector2);
        public Normal Normal3 => new(Vector3);
        public Normal Normal4 => new(Vector4);

        public Plane Plane1 => new() { Normal = Vector1, Point = Vertex1 };
        public Plane Plane2 => new() { Normal = Vector3, Point = Vertex5 };
        public Plane Plane3 => new() { Normal = Vector4, Point = Vertex3 };

        public Ray Ray1 => new() { Direction = Vector1.Normalize(), Origin = Vertex2 };
        public Ray Ray2 => new() { Direction = Vector1.Normalize(), Origin = Vertex3 };
        public Ray Ray3 => new() { Direction = Vector2.Normalize(), Origin = Vertex4 };
        public Ray Ray4 => new() { Direction = Vector3.Normalize(), Origin = Vertex1 };
        public Ray Ray5 => new() { Direction = Vector4.Normalize(), Origin = Vertex5 };
        public Ray Ray6 =>  new() { Direction = Vector4.Normalize(), Origin = Vertex6 };

        public Sphere Sphere1 => new() { };

        public Vector Vector1 => new(0, 0, 4);
        public Vector Vector2 => new(-3, -4, -12);
        public Vector Vector3 => new(1, 1, 1);
        public Vector Vector4 => new(1, -1, 0);
        public Vector Vector5 => new(-1, 1, 0);

        public Vertex Vertex1 => new(0, 0, 0);
        public Vertex Vertex2 => new(0, 0, -10);
        public Vertex Vertex3 => new(0, 0, 10);
        public Vertex Vertex4 => new(3, 4, 12);
        public Vertex Vertex5 => new(3, 3, 3);
        public Vertex Vertex6 => new(-1, 1, 0);
        public Vertex Vertex7 => new(4, 1, 0);

        

        public Triangle Triangle1 => new Triangle(Vertex1, Vertex2, Vertex5);
        public Triangle Triangle2 => new Triangle(Vertex1, Vertex5, Vertex2);
        public Triangle Triangle3 => new Triangle(Vertex3, Vertex4, Vertex5);
        public Triangle Triangle4 => new Triangle(Vertex3, Vertex5, Vertex4);
        
    }
}
