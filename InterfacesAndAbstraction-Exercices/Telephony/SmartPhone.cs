using System;

namespace Telephony
{
    public class SmartPhone : ICalling,IBrowsing
    {
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");

        }
        public void Browse(string website)
        {
            {
                Console.WriteLine($"Browsing: {website}!");
            }
        }
    }
}
