using System;
using System.Linq;

namespace Telephony
{
   public class Program
    {

        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var smartPhone = new SmartPhone();
            var stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                if (number.Any(c=>char.IsLetter(c)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    if (number.Length==7)
                    {
                        stationaryPhone.Call(number);
                    }
                    else if (number.Length == 10)
                    {
                        smartPhone.Call(number);
                    }
                }
            }

            var websites = Console.ReadLine().Split();

            foreach (var website in websites)
            {
                if (website.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.Browse(website);
                }
            }
        }
    }
}
