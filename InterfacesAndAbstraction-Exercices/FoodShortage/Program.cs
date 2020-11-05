using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
   public class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split().ToArray();
                if (personInfo.Length==4)
                {
                    Citizen citizen = new Citizen(personInfo[0], int.Parse(personInfo[1]), personInfo[2], personInfo[3]);
                    persons.Add(citizen);
                }
                else if (personInfo.Length==3)
                {
                    Rebel rebel = new Rebel(personInfo[0], int.Parse(personInfo[1]), personInfo[2]);
                    persons.Add(rebel);
                }

            }

          

            while (true)
            {
                string input = Console.ReadLine();
                if(input== "End")
                {
                    break;
                }
                else
                {
                    foreach (var person in persons)
                    {
                        if (person.Name==input)
                        {
                            person.BuyFood();
                        }
                    }
                }
            }

            Console.WriteLine(persons.Sum(p=>p.Food));
            
        }
    }
}
