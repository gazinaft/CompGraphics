using System;
using System.Drawing;

namespace Core
{
    public static class Coloristycs
    {
        public static Color Add(Color f, Color s)
        {
            return Color.FromArgb(ColorClamp(f.R + s.R), ColorClamp(f.G + s.G), ColorClamp(f.B + s.B));
        }

        public static Color Mult(Color c, float coef)
        {
            return Color.FromArgb(ColorClamp((int)(c.R * coef)),
                ColorClamp((int)(c.G * coef)),
                ColorClamp((int)(c.B * coef)));
        }

        public static Color Mult(Color c1, Color c2)
        {
            return Color.FromArgb(ColorClamp(c1.R * c2.R / 255),
                ColorClamp(c1.G * c2.G / 255),
                ColorClamp(c1.B * c2.B / 255));
        }

        
        public static int ColorClamp(int x)
        {
            return Math.Clamp(x, 0, 255);
        }

    }
}