using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public  interface IDraw

    {
        public string DrawShape(IShape shape);
    }
}
