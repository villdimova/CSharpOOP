using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.30;

        public override List<Type> EatenFood => 
            new List<Type>() { typeof(Meat),typeof(Vegetable)};

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow");
        }
    }
}
