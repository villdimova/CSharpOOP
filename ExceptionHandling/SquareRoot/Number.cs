
using System;

namespace SquareRoot
{
    public class Number
    {
        private char numValue;

        public Number(char numValue)
        {
            this.NumValue = numValue;
        }

        public char NumValue
        {
            get
            {
                return this.numValue;
            }
            private set
            {
                if (char.IsLetter(value)||value <= 0)
                {
                    throw new ArgumentException("Invalid number!!!");
                }

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
