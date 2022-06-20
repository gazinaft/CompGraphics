using System;
using System.Drawing;
using System.Globalization;
using Core;
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
                .Clockwise(true)
                .Culture(CultureInfo.InvariantCulture)
                .Build();
            
            // var reader = new HardCodeReader();
            // reader.Add(new Triangle(new Vertex(1, 0, 1), new Vertex(2, -2, 0), new Vertex(1, 0, -2)))
            //     .Add(new Triangle(new Vertex(1, 0, 1), new Vertex(1, 0, -2), new Vertex(2, 4, 0)));
            
            //Camera camera = new Camera(100, 100) { Pov = new Vertex(0, 10000, 0) };
            Camera camera = new Camera(100, 100) { Pov = new Vertex(0, 30, 0) };
            var crossFinder = new SimpleCrossFinder();
            
            var tracer = new SimpleTracer(
                camera,
                new DirectionalLight() { Direction = new Vector(0, -1, 0)},
                crossFinder,
                new HardShader(crossFinder, 0.001f),
                Color.LightBlue
                );
            var writer = new PpmWriter(@"D:\Polyteco\Course3\CompGraphics\cow.ppm");

            var traceables = reader.Read(PATH);
            traceables.Add(new Sphere() { Center = new Vertex(1, 20, 3), Radius = 2});
            var pixels = tracer.Trace(traceables);
            writer.Write(pixels);
        }
    }
}
