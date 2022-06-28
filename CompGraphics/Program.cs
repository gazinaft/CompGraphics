using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using AccelerationStructures;
using CompGraphics.Materials;
using Core;
using GeometricObjects;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using Matrix;
using ObjReader;

namespace CompGraphics
{
    class Program
    {
        

        static void Main(string[] args)
        {
            // if (args.Length == 0)
            // {
            //     Console.WriteLine("Pass cli arguments");
            //     Console.WriteLine("For example: raytracer.exe --source=cow.obj --output=rendered.ppm");
            // }
            //
            // var cliArgs = new Dictionary<string, string>();
            // foreach (var arg in args)
            // {
            //     var spl = arg.Split("=");
            //     cliArgs[spl[0]] = spl[1];
            // }
            //
            // if (!cliArgs.ContainsKey("--source"))
            // {
            //     return;
            // }
            //
            // string readPath = cliArgs["--source"];
            // string writePath = "Figures.ppm";
            // if (cliArgs.ContainsKey("--output"))
            // {
            //     writePath = cliArgs["--output"];
            // }
            
            string readPath = "cow.obj";
            string writePath = "Figures.ppm";
            
            var reader = ObjReaderBuilder.Init()
                .Clockwise(true)
                .Culture(CultureInfo.InvariantCulture)
                .Build();
            
            Camera camera = new Camera(200, 200) { Pov = new Vertex(0, 30, 0) };;

            var traceables = reader.Read(readPath);
            var cFinder = new BvhAccelStruct();
            var cow = new Mesh(new Lambert(cFinder) { MColor = Color.Aqua })
            {
                Traceables = traceables
            };
            var sphere = new Mesh(new Lambert(cFinder) {MColor = Color.White})
            {
                Traceables = new List<ITraceable>
                {
                    new Sphere { Center = new Vertex(1, 20, 3) , Radius = 2}
                },
            };

            var scene = new Scene
            {
                Meshes = new List<Mesh>
                {
                    cow, sphere
                },
                Lights = new List<ILighting> {
                    new DirectionalLight
                    {
                        Direction = new Vector(-1, 0, 0),
                        Intensity = 1f,
                        LColor = Color.White
                    }
                }
            };
            var tracer = new AccelTracer(
                camera, Color.LightBlue,
                cFinder,
                scene
            );
            var writer = new PpmWriter(writePath);

            Transformations.Rotate(traceables.Cast<Triangle>(), new Vector(1, 0, 0), 90);
            var pixels = tracer.Trace();
            writer.Write(pixels);
        }
    }
}
