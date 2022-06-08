﻿using System;
using System.Drawing;
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
            reader
                .Add(new Sphere() { Center = new Vertex(-5, 0, 0), Radius = 10 });
                // .Add(new Plane() { Normal = new Vector(1, 3, 1).Normalize(), Point = new Vertex(-2, 0, 0) });
                // .Add(new Triangle(new Vertex(1, -10, 10), new Vertex(1, -10, -10), new Vertex(1, 10, 0)));
                
            var tracer = new SimpleTracer(
                new Camera(300, 300) {Pov = new Vertex(20, 0, 0)},
                new DirectionalLight() {Direction = new Vector(-1, -1, 1)},
                new SimpleCrossFinder(),
                Color.LightBlue
                );
            var writer = new PpmWriter("/run/media/gazinaft/d/prog/graphics/CompGraphics/Figures.ppm");

            writer.Write(tracer.Trace(reader.Read(PATH)));
        }
    }
}
