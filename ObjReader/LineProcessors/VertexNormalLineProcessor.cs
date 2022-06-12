using GeometricObjects.Basic;
using System.Globalization;

namespace ObjReader
{
    class VertexNormalLineProcessor : ILineProcessor
    {
        private readonly ObjPool objPool;
        private readonly CultureInfo culture;

        public VertexNormalLineProcessor(ObjPool objPool, CultureInfo culture)
        {
            this.objPool = objPool;
            this.culture = culture;
        }

        public string Keyword => "vn";

        public void Execute(string line)
        {
            var splitLine = line.Split(' ');
            var v0 = Parse(splitLine[1]);
            var v1 = Parse(splitLine[2]);
            var v2 = Parse(splitLine[3]);
            Vector v = new(v0, v1, v2);
            Normal n = new(v);
            objPool.Normals.Add(n);
        }

        private double Parse(string s) => double.Parse(s, culture);
    }
}
