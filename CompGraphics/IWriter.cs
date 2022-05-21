using System.Drawing;

namespace CompGraphics
{
    public interface IWriter
    {
        public void Write(Color[,] pixels);
    }
}