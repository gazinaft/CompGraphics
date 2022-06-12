using Core;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ObjReader
{
    public class ObjReaderBuilder
    {
        private bool isClockwise;
        private CultureInfo culture;

        private ObjReaderBuilder()
        {
            isClockwise = false;
            culture = CultureInfo.CurrentCulture;
        }

        public IReader Build()
        {
            ObjPool objPool = new();
            var proc = new List<ILineProcessor>
            {
                new CommentLineProcessor(),
                new FigureLineProcessor(objPool, isClockwise),
                new VertexLineProcessor(objPool, culture),
                new VertexNormalLineProcessor(objPool, culture),
            };
            return new ObjReader(proc, objPool);
        }

        public ObjReaderBuilder Clockwise(bool clockwise)
        {
            isClockwise = clockwise;
            return this;
        }

        public ObjReaderBuilder Culture(CultureInfo culture)
        {
            this.culture = culture;
            return this;
        }

        public static ObjReaderBuilder Init()
        {
            return new ObjReaderBuilder();
        }
    }
}
