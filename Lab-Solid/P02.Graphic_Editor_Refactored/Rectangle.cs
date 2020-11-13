using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        public Rectangle(double wdth, double height)
        {
            Wdth = wdth;
            Height = height;
        }

        public double  Wdth { get; set; }

        public double Height { get; set; }
    }
}
