using System;
using System.Drawing;
using Core;
using GeometricObjects.Basic;

namespace CompGraphics
{

    public class AmbientLight : ILighting
    {
        public Color LColor { get; set; }
        public float Intensity { get; set; }
        private Random _rand = new Random();


        public Ray ShadowRay(Vector norm, Vertex crossPoint)
        {
            var randVec = new Vector(_rand.NextDouble() * 10 - 5, _rand.NextDouble() * 10 - 5,
                _rand.NextDouble() * 10 - 5);
            if (randVec.Dot(norm) < 0)
            {
                randVec = randVec.Scale(-1);
            }

            return new Ray() { Origin = crossPoint, Direction = randVec };
        }



        public Color OutLight(Vector norm, Vertex crossPoint)
        {
            return Color.FromArgb((int)(LColor.R * Intensity), (int)(LColor.G * Intensity),
                (int)(LColor.B * Intensity));
        }
    }
}
