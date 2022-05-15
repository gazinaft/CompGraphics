using System;
using System.Drawing;

namespace CompGraphics
{
    public class ConsoleWriter : IWriter
    {
        public void Write(Color[,] pixels)
        {
            for (int i = 0; i < pixels.GetLength(1); i++)
            {
                for (int j = 0; j < pixels.GetLength(0); j++)
                {
                    var pixel = pixels[j, i].GetBrightness();
                    var character = pixel switch
                    {
                        > 0.8f => "#",
                        > 0.5f => "O",
                        > 0.2f => "*",
                        > 0f => ".",
                        _ => " "
                    };
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        }
    }
}