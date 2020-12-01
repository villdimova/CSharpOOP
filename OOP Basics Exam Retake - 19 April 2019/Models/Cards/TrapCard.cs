using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int defaultDamageCards = 120;
        private const int defaultHealthPoints = 5;
        public TrapCard(string name) 
            : base(name, defaultDamageCards, defaultHealthPoints)
        {
        }
    }
}
