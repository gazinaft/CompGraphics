using System;
using System.Collections.Generic;
using System.Drawing;
using CompGraphics;
using GeometricObjects;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using NUnit.Framework;

namespace TracerTests;

public class ClosestCrossTest
{
    private SimpleCrossFinder cf;
    private double t;
    private Vertex p;
    private readonly double DELTA = 1e-7;
    
    [SetUp]
    public void Setup()
    {
        cf = new SimpleCrossFinder();
    }

    [Test]
    public void NoCrossing_ZeroObjects()
    {
        var ray = new Ray {Direction = new Vector(1, 1, 1), Origin = new Vertex(1, 1, 1)};
        var res = cf.ClosestCross(ray, new List<ITraceable>(), out t, out p);
        Assert.IsNull(res);
    }

    [Test]
    public void Crossing_OneObject()
    {
        // plane in the point location
        var ray = new Ray { Origin = new Vertex(0, 0, 0), Direction = new Vector(1, 1, 1)};
        var plane = new Plane() { Point = new Vertex(1, 1, 1), Normal = new Vector(-1, -3, -1)};
        var resPlane = cf.ClosestCross(ray, new List<ITraceable> { plane }, out t, out p);
        Assert.AreSame(resPlane, plane);
        Assert.AreEqual(t, 1.7320508075688772, DELTA);

        // sphere inside
        var sphere = new Sphere() {Center = new Vertex(0, -3, 0), Radius = 5};
        var resSphere = cf.ClosestCross(ray, new List<ITraceable> {sphere}, out t, out p);
        Assert.AreSame(sphere, resSphere);
        Assert.AreEqual(t, 2.6268481359717963, DELTA);
        
        // sphere outside
        var ray2 = new Ray { Origin = new Vertex(4, 1, 0) , Direction = new Vector(-1, 0, 0)};
        var resSphere2 = cf.ClosestCross(ray2, new List<ITraceable> { sphere }, out t, out p);
        Assert.AreSame(resSphere2, sphere);
        Assert.AreEqual(t, 1.0, DELTA);

    }

    [Test]
    public void Crossing_ManyObjects()
    {
        var ray = new Ray { Origin = new Vertex(0, 0, 0), Direction = new Vector(1, 0, 0) };
        // plane is closest at distance 1
        var plane = new Plane { Point = new Vertex(1, 0, 0), Normal = new Vector(-1, -1, 0) };
        // triangle is further at distance 3
        var triangle = new Triangle(new Vertex(3, -1, 2), new Vertex(3, 3, 0), new Vertex(3, -3, -3));
        // sphere is furthest at distance 4
        var sphere = new Sphere { Center = new Vertex(7, 0, 0), Radius = 3 };

        // default
        var res = cf.ClosestCross(ray, new List<ITraceable> { plane, triangle, sphere }, out t, out p);
        Assert.AreSame(res, plane);
        Assert.AreEqual(t, 1, DELTA);
        
        // change order in array
        var res2 = cf.ClosestCross(ray, new List<ITraceable> { sphere, plane, triangle }, out t, out p);
        Assert.AreSame(res2, plane);
        Assert.AreEqual(t, 1, DELTA);
        
        // adjust sphere radius to be in front of plane
        sphere.Radius = 6.1;
        var res3 = cf.ClosestCross(ray, new List<ITraceable> { sphere, plane, triangle }, out t, out p);
        Assert.AreSame(res3, sphere);
        Assert.AreEqual(t, 0.9, DELTA);
    }

    [Test]
    public void AnyCrossTest()
    {
        var ray = new Ray { Origin = new Vertex(10.1, 0, 0), Direction = new Vector(1, 0, 0) };
        // plane is closest at distance 1
        var plane = new Plane { Point = new Vertex(1, 0, 0), Normal = new Vector(-1, -1, 0) };
        // triangle is further at distance 3
        var triangle = new Triangle(new Vertex(3, -1, 2), new Vertex(3, 3, 0), new Vertex(3, -3, -3));
        // sphere is furthest at distance 4
        var sphere = new Sphere { Center = new Vertex(7, 0, 0), Radius = 3 };
        double t = 0.0;
        Vertex p = new Vertex();
        var res = cf.AnyCross(ray, new List<ITraceable> { plane, triangle, sphere }, out t);
        Assert.AreEqual(res, false);
    }
}