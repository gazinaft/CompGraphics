using System.Drawing;
using AccelerationStructures;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;

namespace CompGraphics.Materials
{

    public class Lambert : IMaterial
    {
        private static float BIAS = 0.01f;
        private ICrossFinder _crossFinder;
        
        public Lambert(ICrossFinder crossFinder)
        {
            _crossFinder = crossFinder;
        }
        
        public Color MColor { get; set; }
        public Color BRDF(Ray r, Vertex crossPoint, Vector norm, Scene scene)
        {
            var castPoint = crossPoint + norm.Scale(BIAS);
            var resLighting = Color.Black;
            foreach (ILighting l in scene.Lights)
            {
                var ray = l.ShadowRay(norm, castPoint);
                var t = 0.0;
                if (_crossFinder.AnyCross(ray))
                {
                    continue;
                }

                resLighting = Coloristycs.Add(resLighting, l.OutLight(norm, castPoint));
            }

            return Coloristycs.Mult(resLighting, MColor);
        }


    }

}