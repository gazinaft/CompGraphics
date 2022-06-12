using System.Drawing;

namespace Core
{
    public interface IWriter
    {
        public void Write(Color[,] pixels);
    }
}
