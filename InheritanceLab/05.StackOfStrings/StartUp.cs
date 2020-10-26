using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new List<string> { "Maria", "Mitko", "Dani" };
            var stack = new StackOfStrings();
            stack.AddRange(list);

            Console.WriteLine(String.Join(", ",stack));


        }
    }
}
