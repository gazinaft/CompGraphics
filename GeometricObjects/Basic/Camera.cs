using System;

namespace GeometricObjects.Basic
{
    // right-handed coordinates
    public class Camera
    {
        private Vector _direction = new Vector(-1.0, 0, 0);
        public Vertex Pov { get; set; }

        public Vector Direction
        {
            get => _direction;
            set => _direction = value.Normalize();
        } // TODO: add rotation and on set recalculate corners

        public double Distance { get; set; }
        public int Height = 20;
        public int Width = 20;
        public double CameraScale { get; set; }

        
        private Vertex TopLeft = new Vertex(1.0, 10.0, 10.0);
        private Vertex TopRight = new Vertex(1.0, 10.0, -10.0);
        private Vertex BottomLeft = new Vertex(1.0, -10.0, 10.0);

        private Vector PlusX => (TopRight - TopLeft).Scale(1.0/Width); // X increases to right
        private Vector PlusY => (BottomLeft - TopLeft).Scale(1.0/Height); // Y increases downwards

        private Vertex PixelLocation(int x, int y)
        {
            return TopLeft + PlusX.Scale(x) + PlusY.Scale(y);
        }

        public Ray GetRay(int x, int y)
        {
            return new Ray() { Origin = Pov, Direction = (PixelLocation(x, y) - Pov).Normalize() };
        }
    }
}
