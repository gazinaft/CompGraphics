using System.Drawing;
using GeometricObjects.Basic;

namespace GeometricObjects
{
    public interface ILighting
    {
        Color LColor { get; set; }
        float Intensity { get; set; }

        Ray ShadowRay(Vector norm, Vertex crossPoint);

        Color OutLight(Vector norm, Vertex crossPoint);
    }
}