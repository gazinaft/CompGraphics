using Core;
using System.Drawing;
using System.IO;

namespace CompGraphics
{
    public class PpmWriter: IWriter
    {
        private string _path;
    
        public PpmWriter(string path)
        {
            _path = path;
        }
    
        public void Write(Color[,] pixels)
        {
            StreamWriter file = new(_path);
            file.WriteLine("P3");
            file.WriteLine(pixels.GetLength(0) + " " + pixels.GetLength(1));
            file.WriteLine("255");
            file.WriteLine();
            for (int i = 0; i < pixels.GetLength(1); i++)
            {
                for (int j = 0; j < pixels.GetLength(0); j++)
                {
                    var p = pixels[j, i];
                    file.WriteLine(p.R + " " + p.G + " " + p.B);
                }
            }
            file.Flush();
            file.Close();
        }
    }
}