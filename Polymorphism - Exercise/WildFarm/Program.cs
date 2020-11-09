using System;
using WildFarm.Factories;
using WildFarm.Animals;
using WildFarm.Foods;
using System.Collections.Generic;

namespace WildFarm
{
  public  class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input== "End")
                {
                    break;
                }
                else
                {
                    var animalInfo = input.Split();
                    var foodinfo = Console.ReadLine().Split();
                    AnimalFactory animalFactory = new AnimalFactory();
                    Animal animal = animalFactory.GetAnimal(animalInfo);
                    FoodFactory foodFactory = new FoodFactory();
                    animal.ProduceSound();
                    Food food = foodFactory.GetFood(foodinfo[0], int.Parse(foodinfo[1]));
                    try
                    {
                        
                        animal.Feed(food, animal.GetType().Name);
                        

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }


                    animals.Add(animal);
                }

                
            }

            foreach (var animal in animals)
            {
               
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
