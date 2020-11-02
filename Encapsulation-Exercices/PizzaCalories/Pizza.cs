using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int MaxNameLength = 15;
        private const int MinNameLength = 1;


        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name,Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.Dough = dough;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get
            {
                return this.dough;
            }

           set
            {
                this.dough = value;
            }
            
        }

        private int ToppingsCount => this.toppings.Count;
        public double TotalCalories => CalculateTotalCalories();
        
        private double CalculateTotalCalories()
        {
            double toppingsCalories = toppings.Sum(t => t.ToppingCalories);
            double totalCalories = toppingsCalories + dough.DoughCalories;
            return totalCalories;
        }

        public void AddToppings(Topping topping)
        {
            if (this.ToppingsCount == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);

        }


    }
}
