﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Core;
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
            
            // var reader = new HardCodeReader();
            // reader.Add(new Triangle(new Vertex(1, 0, 1), new Vertex(2, -2, 0), new Vertex(1, 0, -2)))
            //     .Add(new Triangle(new Vertex(1, 0, 1), new Vertex(1, 0, -2), new Vertex(2, 4, 0)));
            
            //Camera camera = new Camera(100, 100) { Pov = new Vertex(0, 10000, 0) };
            Camera camera = new Camera(100, 100) { Pov = new Vertex(0, 30, 0) };
            var crossFinder = new SimpleCrossFinder();
            
            var tracer = new SimpleTracer(
                camera,
                // new DirectionalLight() { Direction = new Vector(-1, 0, 0), Intensity = 1, LColor = Color.Wheat},
                new AmbientLight() { Intensity = 1, LColor = Color.Blue},
                crossFinder,
                new HardShader(crossFinder, 0.001f),
                Color.LightBlue
                );
            var writer = new PpmWriter(writePath);

            var traceables = reader.Read(readPath);
            Transformations.Rotate(traceables.Cast<Triangle>(), new Vector(1, 0, 0), 90);
            traceables.Add(new Sphere() { Center = new Vertex(1, 20, 3), Radius = 2});
            var pixels = tracer.Trace(traceables);
            writer.Write(pixels);
        }
    }
}
