using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead||enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType().Name == nameof(Beginner)) 
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (true)
            {

                var attacPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                enemyPlayer.TakeDamage(attacPlayerTotalDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);


                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
