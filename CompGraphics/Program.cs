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
                new Camera(300, 300) {Pov = new Vertex(3, 0, 0)},
                new DirectionalLight() {Direction = new Vector(-1, 0, 0)},
                new SimpleCrossFinder(),
                Color.LightBlue
                );
            var writer = new PpmWriter(@"D:\Polyteco\Course3\CompGraphics\cow.ppm");

            var traceables = reader.Read(PATH);
            var pixels = tracer.Trace(traceables);
            writer.Write(pixels);
        }
    }
}
