using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle(5, 3);
            Square square = new Square(4);
            Circle circle = new Circle(5);

            List<IShape> shapes = new List<IShape>();
            shapes.Add(rectangle);
            shapes.Add(circle);
            shapes.Add(square);

            foreach (var shape in shapes)
            {
                GraphicEditor graphicEditor = new GraphicEditor();
                Console.WriteLine(graphicEditor.DrawShape(shape));
            }
        }
    }
}
