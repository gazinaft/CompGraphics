using System.Drawing;
using Core;

namespace GeometricObjects.Basic
{
    public class DirectionalLight: ILighting
    {
        private Vector direction;

        public Vector Direction
        {
            get => direction;
            set => direction = value.Normalize();
        }

        public Color LColor { get; set; }
        public float Intensity { get; set; }
        public Ray ShadowRay(Vector norm, Vertex crossPoint)
        {
            return new Ray { Origin = crossPoint, Direction = Direction.Scale(-1) };
        }

        public Color OutLight(Vector norm, Vertex crossPoint)
        {
            var dot = Direction.Scale(-1).Dot(norm);
            if (dot < 0)
            {
                return Color.Black;
            }

            return Coloristycs.Mult(LColor, (float)(dot * Intensity));
        }
    }
}
