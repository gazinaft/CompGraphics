using System.Drawing;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics.Materials;

public class Specular : IMaterial
{
    public Color MColor { get; set; }
    public Color BRDF(Ray r, Vertex crossPoint, Vector norm, Scene scene)
    {
        throw new System.NotImplementedException();
    }
}