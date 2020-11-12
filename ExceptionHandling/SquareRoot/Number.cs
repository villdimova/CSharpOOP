
using System;

namespace SquareRoot
{
    public class Number
    {
        private int numValue;

        public Number(int numValue)
        {
            this.NumValue = numValue;
        }

        public int NumValue
        {
            get
            {
                return this.numValue;
            }
            private set
            {
            
            this.numValue = value;
            }
        }


        public double GetSquareRoot()
        {
            double num = double.Parse(this.NumValue.ToString());
            return Math.Sqrt(num);
        }

    }
}
