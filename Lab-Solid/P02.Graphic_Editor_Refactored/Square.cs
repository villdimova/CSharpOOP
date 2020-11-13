using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        public Square(double side)
        {
            this.Side = side;
        }

        public double  Side { get; set; }
    }
}
