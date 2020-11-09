namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.35;

        public override List<Type> EatenFood =>
             new List<Type>() { typeof(Meat),typeof(Vegetable),typeof(Fruit),typeof(Seeds)};

        public override void ProduceSound()
        {
            System.Console.WriteLine("Cluck");
        }
    }
}
