using System;
using GeometricObjects.Basic;
using GeometricObjects.Figures;

namespace CompGraphics
{
    class Program
    {
        private const string PATH = "./cow.obj";

        static void Main(string[] args)
        {
            var reader = new HardCodeReader();
            reader.Add(new Sphere() { Center = new Vertex(-3, 0, 0), Radius = 9});
            var tracer = new SimpleTracer(new Camera() {Pov = new Vertex(12, 0, 0)});
            var writer = new ConsoleWriter();

            writer.Write(tracer.Trace(reader.Read(PATH)));
        }
    }
}
