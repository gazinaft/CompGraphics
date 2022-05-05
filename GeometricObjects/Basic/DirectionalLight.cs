namespace GeometricObjects.Basic
{
    class DirectionalLight
    {
        private Vector direction;

        public Vector Direction
        {
            get => direction;
            set => direction = value.Normalize();
        }
    }
}
