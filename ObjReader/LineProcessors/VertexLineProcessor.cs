using GeometricObjects.Basic;
using System.Globalization;

namespace ObjReader
{
    class VertexLineProcessor : ILineProcessor
    {
        private readonly ObjPool objPool;
        private readonly CultureInfo culture;

        public VertexLineProcessor(ObjPool objPool, CultureInfo culture)
        {
            this.objPool = objPool;
            this.culture = culture;
        }

        public string Keyword => "v";

        public void Execute(string line)
        {
            var splitLine = line.Split(' ');
            var v0 = Parse(splitLine[1]);
            var v1 = Parse(splitLine[2]);
            var v2 = Parse(splitLine[3]);
            Vertex v = new(v0, v1, v2);
            objPool.Vertices.Add(v);
        }

        private double Parse(string s) => double.Parse(s, culture);
    }
}
