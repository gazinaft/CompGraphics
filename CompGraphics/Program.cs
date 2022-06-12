using System;
using System.Drawing;
using System.Globalization;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using ObjReader;

namespace CompGraphics
{
    class Program
    {
        private const string PATH = @"D:\Polyteco\Course3\CompGraphics\cow.obj";

        static void Main(string[] args)
        {
            var reader = ObjReaderBuilder.Init()
                .Clockwise(false)
                .Culture(CultureInfo.InvariantCulture)
                .Build();
                
            var tracer = new SimpleTracer(
                new Camera(1000, 1000) {Pov = new Vertex(3, 0, 0)},
                new DirectionalLight() {Direction = new Vector(-1, 0, 0)},
                new SimpleCrossFinder(),
                Color.LightBlue
                );
            var writer = new PpmWriter(@"D:\Polyteco\Course3\CompGraphics\Figures.ppm");

            writer.Write(tracer.Trace(reader.Read(PATH)));
        }
    }
}
