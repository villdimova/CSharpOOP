using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                Number num = new Number(n);
                Console.WriteLine(num.GetSquareRoot()); 

            }
            catch (FormatException fe)
            {

                Console.WriteLine(fe.Message);
            }
          

        }
    }
}
