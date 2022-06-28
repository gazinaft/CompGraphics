using System.Drawing;
using GeometricObjects.Basic;

namespace Core
{
    public interface IMaterial
    {
        Color MColor { get; set; }
        
        Color BRDF(Ray r, Vertex crossPoint, Color inLight);
    }
}