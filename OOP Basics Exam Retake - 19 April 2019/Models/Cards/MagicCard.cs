using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int defaultDamageCards = 5;
        private const int defaultHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, defaultDamageCards, defaultHealthPoints)
        {
        }
    }
}
