
using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private const double calories = 2;
        private readonly Dictionary<string, double> DefaultToppings = new Dictionary<string, double>()
        {
            {"meat",1.2},
            {"veggies",0.8},
            {"cheese",1.1},
            {"sauce",0.9}

        };

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;

        }

        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }
            private set
            {
                if (!this.DefaultToppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value.ToLower();
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType.Replace(toppingType[0],char.ToUpper(toppingType[0]))} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public double ToppingCalories => this.DefaultToppings[this.ToppingType]
                                        * calories
                                        * this.Weight;

    }
}
