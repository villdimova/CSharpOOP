using System;

namespace FootballTeam
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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
        public Stats Stats
        {
            get
            {
                return this.stats;
            }

            private set
            {
                this.stats = value;
            }
        }
        internal double OverallSkill => this.Stats.SkillLevel;

    }
}
