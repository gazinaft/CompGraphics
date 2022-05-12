using System;
using GeometricObjects.Basic;

namespace CompGraphics
{
    class Program
    {
        private const string PATH = "./cow.obj";

        static void Main(string[] args)
        {
            var reader = new HardCodeReader();
            var tracer = new SimpleTracer(new Camera());
            var writer = new ConsoleWriter();

            writer.Write(tracer.Trace(reader.Read(PATH)));
        }
    }
}
