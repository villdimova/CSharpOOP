namespace FootballTeam
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Runtime.CompilerServices;

    public class Team
    {
        private string name;
        private readonly ICollection<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        private int NumPlayers => players.Count;

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Sum(p => p.OverallSkill) / NumPlayers);

            }
        }

        public void AddPlayer(Player player)
        {
            if (!this.players.Contains(player))
            {
                this.players.Add(player);
            }

        }

        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);
            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {name} is not in {this.Name} team.");
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return ($"{this.Name} - {this.Rating}");
        }

    }
}
