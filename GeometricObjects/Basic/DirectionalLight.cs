namespace GeometricObjects.Basic
{
    public class DirectionalLight
    {
        private Vector direction;

        public Vector Direction
        {
            get => direction;
            set => direction = value.Normalize().Scale(-1);
        }
    }
}
