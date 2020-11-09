using System;
using System.Collections.Generic;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            int n = int.Parse(Console.ReadLine());
            var heroes = new List<BaseHero>();
            
           while(true)
            {
                if (heroes.Count==n)
                {
                    break;
                }
                string name = Console.ReadLine();
                string typeHero = Console.ReadLine();
                try
                {
                    HeroFactory factory = new HeroFactory();

                    BaseHero hero = factory.GetHero(typeHero, name);

                    heroes.Add(hero);

                }
                catch (Exception ex )
                {

                    Console.WriteLine(ex.Message); 
                }
                
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;

            foreach (var hero in heroes)
            {
                totalPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }

            if (bossPower<=totalPower)
            {
                Console.WriteLine("Victory!");

            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
