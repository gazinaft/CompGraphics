namespace GeometricObjects.Basic
{
    public class Camera
    {
        public Vertex Pov { get; set; }
        public Vector Direction { get; set; } // TODO: on set recalculate corners
        public double Distance { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double CameraScale { get; set; }
        
        private Vertex TopLeft { get; set; } // TODO: calculate location of these Vertices
        private Vertex TopRight { get;  set; }
        private Vertex BottomLeft { get; set; }

        private Vector PlusX => (TopRight - TopLeft).Scale(1.0/Width); // X increases to right
        private Vector PlusY => (BottomLeft - TopRight).Scale(1.0/Height); // Y increases downwards

        private Vertex PixelLocation(int x, int y)
        {
            return TopLeft + PlusX.Scale(x) + PlusY.Scale(y);
        }

        public Ray GetRay(int x, int y)
        {
            return new Ray() { Origin = Pov, Direction = PixelLocation(x, y) - Pov };
        }
    }
}
