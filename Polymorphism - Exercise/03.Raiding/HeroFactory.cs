using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class HeroFactory
    {
        public BaseHero GetHero(string heroType,string name)
        {
            BaseHero hero = null;
            if (heroType== "Paladin")
            {
                hero = new Paladin(name, 100);
                
            }
            else if (heroType == "Druid")
            {
               hero = new Druid(name, 80);
               
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name, 80);
                
            }

            else if (heroType == "Warrior")
            {
                hero = new Warrior(name, 100);
            }

            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return hero;
        }
    }
}
