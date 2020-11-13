using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor:IDraw
    {
        public string DrawShape(IShape shape)
        {
            return ($"I'm {shape.GetType().Name}");
        }
    }
}
