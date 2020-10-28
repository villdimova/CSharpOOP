﻿
namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50M;
        public Coffee(string name,double caffeine) 
            : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine  { get; set; }

        public override double Milliliters  => coffeeMilliliters; 

        public override decimal Price => coffeePrice; 

    }
}
