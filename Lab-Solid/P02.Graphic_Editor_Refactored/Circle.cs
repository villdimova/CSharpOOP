using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Ridius = radius;
        }
        public double Ridius { get; set; }
    }
}
