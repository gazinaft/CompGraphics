using System;

namespace GeometricObjects.Basic
{
    // right-handed coordinates
    public class Camera
    {
        private Vector _direction = new Vector(-1.0, 0, 0);
        //private Vector _direction = new Vector(0, -1.0, 0);//wtf
        public Vertex Pov { get; set; }

        public Vector Direction
        {
            get => _direction;
            set => _direction = value.Normalize();
        } // TODO: add rotation and on set recalculate corners

        public double Distance { get; set; }
        public int Height = 20;
        public int Width = 20;
        public int ScaleX;
        public int ScaleY;

        
        private Vertex TopLeft;
        private Vertex TopRight;
        private Vertex BottomLeft;

        public Camera(int scaleX, int scaleY)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            
            TopLeft = new Vertex(Width/2.0, 0, Height/2.0);
            TopRight = new Vertex(-Width/2.0, 0, Height/2.0);
            BottomLeft = new Vertex(Width/2.0, 0, -Height/2.0);;
        }
        
        private Vector PlusX => (TopRight - TopLeft).Scale(1.0/ScaleX); // X increases to right
        private Vector PlusY => (BottomLeft - TopLeft).Scale(1.0/ScaleY); // Y increases downwards

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
