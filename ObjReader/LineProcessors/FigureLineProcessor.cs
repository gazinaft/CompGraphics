using GeometricObjects.Basic;
using GeometricObjects.Figures;
using System;
using System.Linq;

namespace ObjReader
{
    class FigureLineProcessor : ILineProcessor
    {
        private readonly ObjPool objPool;
        private readonly bool isClockwise;

        public FigureLineProcessor(ObjPool objPool, bool isClockwise)
        {
            this.objPool = objPool;
            this.isClockwise = isClockwise;
        }

        public string Keyword => "f";

        public void Execute(string line)
        {
            var indexes = line.Split(' ')[1..];
            int indexesLength = indexes.Length;

            Vertex[] vertices = new Vertex[indexesLength];
            for (int i = 0; i < indexesLength; i++)
            {
                var indexSplit = indexes[i].Split('/');
                vertices[i] = objPool.Vertices[int.Parse(indexSplit[0]) - 1];
                if (indexSplit.Length > 0 && int.TryParse(indexSplit[1], out int textureIndex))
                {
                    //TODO: Add vertex texture logic
                }
                if (indexSplit.Length > 1 && int.TryParse(indexSplit[2], out int normalIndex))
                {
                    vertices[i].Normal = objPool.Normals[normalIndex - 1];
                }
            }

            if (indexesLength != 3)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (!isClockwise)
                {
                    vertices = vertices.Reverse().ToArray();
                }
                Triangle t = new(vertices[0], vertices[1], vertices[2]);
                objPool.Traceables.Add(t);
            }
        }
    }
}
