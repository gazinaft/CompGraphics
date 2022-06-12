using Core;
using GeometricObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ObjReader
{
    class ObjReader : IReader
    {
        private readonly IEnumerable<ILineProcessor> processors;
        private readonly ObjPool objPool;

        public ObjReader(IEnumerable<ILineProcessor> processors, ObjPool objPool)
        {
            this.processors = processors;
            this.objPool = objPool;
        }

        public ITraceable[] Read(string path)
        {
            using FileStream obj = File.OpenRead(path);
            using StreamReader reader = new(obj);
            string line;
            int readlines = 0;
            while ((line = reader.ReadLine()) != null)
            {
                var keyword = line.Substring(0, line.IndexOf(' '));
                processors.SingleOrDefault(p => p.Keyword == keyword)?.Execute(line);
                readlines++;
            }
            return objPool.GetTraceables();
        }
    }
}
