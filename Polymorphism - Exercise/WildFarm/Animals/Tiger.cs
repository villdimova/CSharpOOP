namespace WildFarm.Animals
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Foods;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 1.0;

        public override List<Type> EatenFood =>
             new List<Type>() {typeof(Meat) };

        public override void ProduceSound()
        {
            System.Console.WriteLine("ROAR!!!");
        }
    }
}
