using System.Drawing;
using Core;
using GeometricObjects.Basic;

namespace CompGraphics;

public class PointLight: ILighting
{
    public Color LColor { get; set; }
    public float Intensity { get; set; }
    public float Fading { get; set; }

    public PointLight(Vertex position, float fading = 10f)
    {
        Position = position;
        Fading = fading;
    }
    
    public Vertex Position { get; set; }
    
    public Ray ShadowRay(Vector norm, Vertex crossPoint)
    {
        return new Ray() { Origin = crossPoint, Direction = Position - crossPoint };
    }

    public Color OutLight(Vector norm, Vertex crossPoint)
    {
        var distance = (Position - crossPoint).Abs;
        var distanceMultiplier = Fading / (distance * distance);

        return Coloristycs.Mult(LColor, (float)(distanceMultiplier * Intensity));
    }
}