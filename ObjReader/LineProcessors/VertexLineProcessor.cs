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
            double scale = 20; //how tf does this work
            Vertex v = new(v0 * scale, v1 * scale, v2 * scale);
            objPool.Vertices.Add(v);
        }

        private double Parse(string s) => double.Parse(s, culture);
    }
}
