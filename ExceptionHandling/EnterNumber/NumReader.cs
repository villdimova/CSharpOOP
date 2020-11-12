using System;
using System.Collections.Generic;
using System.Text;

namespace EnterNumber
{
    public class NumReader
    {
       
        public bool ReadNumber(int start, int end)
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
