

namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
           
        }

        public override double WeightMultiplier => 0.25;

        public override List<Type> EatenFood =>
             new List<Type>() { typeof(Meat) };

        public override void ProduceSound()
        {
            System.Console.WriteLine("Hoot Hoot");
        }
    }
}
