using System;

namespace EnterNumber
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter start value:");
            int start = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter end value:");
            int end = int.Parse(Console.ReadLine());

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Enter number:");

                    NumReader numReader = new NumReader();
                    while (!numReader.ReadNumber(start,end))
                    {
                        Console.WriteLine("Enter valid number!!!");
                        numReader.ReadNumber(start, end);
                    }

                    
                }
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid Number!"); ;
            }
        }
    }
}
