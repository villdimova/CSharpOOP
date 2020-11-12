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

                    if (!ReadNumber(start,end))
                    {
                        Console.WriteLine("You have entered wrong number!");
                        i = -1;

                    }

                 }
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid Number!"); ;
            }


            static bool ReadNumber(int start, int end)

            {
                    int n = int.Parse(Console.ReadLine());
                    if (n < start || n > end)
                    {
                        return false;
                        

                    }
                

                return true;
            }

        }
    }
}
