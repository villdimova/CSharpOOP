using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            char n = char.Parse(Console.ReadLine());

            try
            {
                Number num = new Number(n);
                Console.WriteLine(num.GetSquareRoot()); 

            }
            catch (Exception ex)
            {

                Console.WriteLine("Invalid number!"); ;
            }
          

        }
    }
}
