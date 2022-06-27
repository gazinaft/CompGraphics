using System.Drawing;
using Core;
using GeometricObjects.Basic;

namespace CompGraphics.Materials
{

    public class Lambert : IMaterial
    {
        public Color MColor { get; set; }

        public Color BRDF(Ray r, Vertex crossPoint, Color inLight)
        {
            return Coloristycs.Mult(MColor, inLight);
        }
    }

}