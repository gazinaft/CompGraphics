using System.Drawing;
using GeometricObjects.Basic;

namespace GeometricObjects
{
    public interface IMaterial
    {
        Color MColor { get; set; }
        
        Color BRDF(Ray r, Vertex crossPoint, Vector norm, Scene scene);
    }
}