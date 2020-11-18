using System;
using System.Reflection;

namespace ReflectionDemo
{
   public  class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat("Kitty");
            var catType = typeof(Cat);
            var field = catType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(cat,5);

            Console.WriteLine(cat.GetId());

        }
    }
}
