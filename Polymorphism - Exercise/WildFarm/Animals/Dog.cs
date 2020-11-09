namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.40;

        public override List<Type> EatenFood =>
             new List<Type>() { typeof(Meat) };

        public override void ProduceSound()
        {
            System.Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
