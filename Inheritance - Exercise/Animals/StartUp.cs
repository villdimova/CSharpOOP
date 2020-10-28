using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>(); 

            while (true)
            {
                string animal = Console.ReadLine();
                if (animal=="Beast!")
                {
                    break;
                }
                else
                {
                    var animalInfo = Console.ReadLine().Split().ToArray();
                    var name = animalInfo[0];
                    var age = int.Parse(animalInfo[1]);
                    string gender = null;
                    if (animalInfo.Length>=3)
                    {
                        gender = animalInfo[2];
                    }
                    
                    if (animal=="Cat")
                    {
                        try
                        {
                            Cat currentAnimal = new Cat(name, age, gender);
                            animals.Add(currentAnimal);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        

                    }
                    else if (animal=="Dog")
                    {

                        try
                        {
                            Dog currentAnimal = new Dog(name, age, gender);
                            animals.Add(currentAnimal);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        
                    }
                    else if (animal == "Frog")
                    {
                        try
                        {
                            Frog currentAnimal = new Frog(name, age, gender);
                            animals.Add(currentAnimal);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        
                    }

                    else if (animal == "Kitten")
                    {
                        try
                        {
                            Kitten currentAnimal = new Kitten(name, age);
                            animals.Add(currentAnimal);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        
                    }
                    else if (animal == "Tomcat")
                    {
                        try
                        {
                            Tomcat currentAnimal = new Tomcat(name, age);
                            animals.Add(currentAnimal);
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid input!");
                        }
                        
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                }
            }

            foreach (var animal in animals)
            {
                try
                {
                    Console.WriteLine(animal);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               
            }
        }
    }
}
