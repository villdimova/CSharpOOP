using System;
using System.Collections.Generic;

namespace Shapes
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4, 3);

            List<Shape> shapes = new List<Shape>();
            shapes.Add(circle);
            shapes.Add(rectangle);
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.Draw());
            }
        }
    }
}
