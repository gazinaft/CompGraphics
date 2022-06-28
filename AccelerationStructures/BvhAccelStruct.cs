using GeometricObjects;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace AccelerationStructures
{
    public class BvhAccelStruct : ICrossFinder
    {
        Node root;
        int nodecount = 1;
        long t;
        long stt = 0;
        long bbt = 0;

        public void Apply(IEnumerable<ITraceable> traceables)
        {
            long start, end; //======================
            start = DateTime.Now.Ticks;

            root = CreateNode(traceables);

            end = DateTime.Now.Ticks; //======================
            t += end - start;
            Console.WriteLine(t);
            Console.WriteLine(stt);
            Console.WriteLine(bbt);
        }

        private Node CreateNode(IEnumerable<ITraceable> traceables)
        {
            long end, start;

            Node node = new();
            if (traceables.Count() == 1)
            {
                // TODO: optimize First() or MoveNext()
                // Maybe enumerate collections before passing to method
                // Current exec time for cow.obj: 8.5s
                var enumerator = traceables.GetEnumerator();
                start = DateTime.Now.Ticks;//======================
                enumerator.MoveNext();
                end = DateTime.Now.Ticks;//======================
                var tr = enumerator.Current;

                node.traceable = tr;
                node.AABB = tr.GetBounds();

                stt += end - start;
            }
            //else if (traceables.Count() == 2)
            //{
                  //can be used for optimization
            //}
            else
            {
                // TODO: make better aggregation
                // And/or enumerate collections before passing to method
                // Current exec time for cow.obj: 17s
                start = DateTime.Now.Ticks; //======================
                var bounds = traceables.Select(t => t.GetBounds());

                var mins = traceables.Select(t => t.GetBounds().Min).ToArray();
                var maxs = traceables.Select(t => t.GetBounds().Max).ToArray();

                var minX = mins.Select(m => m.X).Min();
                var minY = mins.Select(m => m.Y).Min();
                var minZ = mins.Select(m => m.Z).Min();
                var maxX = maxs.Select(m => m.X).Max();
                var maxY = maxs.Select(m => m.Y).Max();
                var maxZ = maxs.Select(m => m.Z).Max();
                end = DateTime.Now.Ticks; //======================

                BoundBox bb = new(minX, minY, minZ, maxX, maxY, maxZ);
                node.AABB = bb;

                bbt += end - start;

                // This code is already fast
                // still need to check if will be slowed by optimization
                IEnumerable<ITraceable> tOrdered;
                var edgeX = maxX - minX;
                var edgeY = maxY - minY;
                var edgeZ = maxZ - minZ;

                if (edgeX > edgeY && edgeX > edgeZ)
                    tOrdered = traceables.OrderBy(t => t.GetBounds().Center().Item1);
                else if (edgeY > edgeX && edgeY > edgeZ)
                    tOrdered = traceables.OrderBy(t => t.GetBounds().Center().Item2);
                else
                    tOrdered = traceables.OrderBy(t => t.GetBounds().Center().Item3);

                var median = traceables.Count() / 2;
                node.lesser = CreateNode(tOrdered.Take(median));
                node.greater = CreateNode(tOrdered.Skip(median));
            }

            if (nodecount % 100 == 0)
            {
                Console.WriteLine($"Node {nodecount} added");
            }
            nodecount++;

            return node;
        }

        public ITraceable ClosestCross(Ray ray, out double t, out Vertex p)
        {
            ITraceable closest = null;
            t = double.MaxValue;

            foreach (var node in Raycast(ray, root))
            {
                if (node.traceable.Intersects(ray, out double tt) && tt < t)
                {
                    t = tt;
                    closest = node.traceable;
                }
            }

            p = ray.Origin + ray.Direction.Scale(t);
            return closest;
        }

        public bool AnyCross(Ray ray)
        {
            ITraceable closest = null;

            foreach (var node in Raycast(ray, root))
            {
                if (node.traceable.Intersects(ray, out double tt))
                {
                    return true;
                }
            }

            return false;
        }

        private IEnumerable<Node> Raycast(Ray ray, Node node)
        {
            if (!node.AABB.Intersects(ray, out _)) 
                yield break;

            if (node.IsLeaf) 
                yield return node;

            if (node.lesser != null) 
                foreach (var nodeL in Raycast(ray, node.lesser)) 
                    yield return nodeL;

            if (node.greater != null)
                foreach (var nodeG in Raycast(ray, node.greater))
                    yield return nodeG;
        }

        class Node
        {
            public bool IsLeaf => lesser == null && greater == null;
            public BoundBox AABB = null;
            public Node lesser = null;
            public Node greater = null;
            public ITraceable traceable = null;
        }
    }
}
