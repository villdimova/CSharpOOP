using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"Paladin - {this.Name} healed for {this.Power}";
        }
    }
}
