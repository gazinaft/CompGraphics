using GeometricObjects;
using GeometricObjects.Basic;
using GeometricObjects.Figures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccelerationStructures
{
    public class BvhAccelStruct : IAccelStruct
    {
        Node root;

        public void Apply(IEnumerable<ITraceable> traceables)
        {
            root = CreateNode(traceables);
        }

        private Node CreateNode(IEnumerable<ITraceable> traceables)
        {
            Node node = new();
            if (traceables.Count() == 1)
            {
                var tr = traceables.First();
                node.traceable = tr;
                node.AABB = tr.GetBounds();
            }
            else
            {
                var mins = traceables.Select(t => t.GetBounds().Min).ToArray();
                var maxs = traceables.Select(t => t.GetBounds().Max).ToArray();

                var minX = mins.Select(m => m.X).Min();
                var minY = mins.Select(m => m.Y).Min();
                var minZ = mins.Select(m => m.Z).Min();
                var maxX = maxs.Select(m => m.X).Max();
                var maxY = maxs.Select(m => m.Y).Max();
                var maxZ = maxs.Select(m => m.Z).Max();

                BoundBox bb = new(minX, minY, minZ, maxX, maxY, maxZ);
                node.AABB = bb;

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

                tOrdered = tOrdered.ToArray(); //i hate linq
                var median = traceables.Count() / 2;
                node.lesser = CreateNode(tOrdered.Take(median));
                node.greater = CreateNode(tOrdered.Skip(median));
            }

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
