namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private IPlayerFactory playerFactory;
        private ICardRepository cards;
        private ICardFactory cardFactory;
        private IBattleField battleField;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.playerFactory = new PlayerFactory();
            this.cards = new CardRepository();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddCard(string type, string name)
        {
            ICard card=this.cardFactory.CreateCard(type,name);
            this.cards.Add(card);

           

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this.playerFactory.CreatePlayer(type, username);
            this.players.Add(player);
            

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = players.Find(username);
            var card = cards.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = players.Find(attackUser);
            var enemyPlayer = players.Find(enemyUser);
            battleField.Fight(attackPlayer, enemyPlayer);

            return String.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

       

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in players.Players)
            {
                sb.AppendLine(player.ToString());
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(card.ToString());
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();

        }

    }
}