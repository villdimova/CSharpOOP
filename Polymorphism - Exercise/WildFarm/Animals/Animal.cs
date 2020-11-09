
namespace WildFarm.Animals
{
    using Foods;
    using System;
    using System.Collections.Generic;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;
        

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name
        {
            get { return name; }
            internal set { name = value; }
        }

        public double Weight
        {
            get { return weight; }
            internal set { weight = value; }
        }

        public int FoodEaten
        {
            get { return foodEaten; }
            internal set { foodEaten = value; }
        }

        public abstract double WeightMultiplier { get; }
        public abstract List<Type> EatenFood { get;}

        public abstract void ProduceSound();

        public void Feed(Food food,string animalType)
        {
            if (!this.EatenFood.Contains(food.GetType()))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";

        }
    }
}
