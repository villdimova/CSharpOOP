namespace WildFarm.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WildFarm.Animals;
    class AnimalFactory
    {
        public Animal GetAnimal(string[] animalInfo)
        {
            string type = animalInfo[0].ToLower();
            if (type == "hen")
            {
                return new Hen(animalInfo[1],double.Parse(animalInfo[2]),double.Parse(animalInfo[3]));

            }
            if (type == "owl")
            {
                return new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));

            }
            else if (type == "mouse")
            {
                return new Mouse(animalInfo[1], double.Parse(animalInfo[2]),(animalInfo[3]));
            }
            else if (type == "dog")
            {
                return new Dog(animalInfo[1], double.Parse(animalInfo[2]), (animalInfo[3]));
            }
            else if (type == "cat")
            {
                return new Cat(animalInfo[1], double.Parse(animalInfo[2]), (animalInfo[3]), (animalInfo[4]));
            }
            else if (type == "tiger")
            {
                return new Tiger(animalInfo[1], double.Parse(animalInfo[2]), (animalInfo[3]), (animalInfo[4]));
            }
            else
            {
                throw new ArgumentException("Invalid animal!");
            }
        }
    }
}
