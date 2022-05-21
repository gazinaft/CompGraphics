namespace GeometricObjects.Basic
{
    public class Ray
    {
        private Vector _direction;
        public Vector Direction
        {
            get => _direction;
            set => _direction = value.Normalize();
        }

        public Vertex Origin { get; set; }
    }
}
