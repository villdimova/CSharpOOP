namespace FootballTeam
{
    using System;

    public class Stats
    {

        private const int MaxStat = 100;
        private const int MinStat = 0;

        private const double StatsCount = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between {MinStat} and {MaxStat}.");
                }
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between {MinStat} and {MaxStat}.");
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between {MinStat} and {MaxStat}.");
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between {MinStat} and {MaxStat}.");
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (value < MinStat || value > MaxStat)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between {MinStat} and {MaxStat}.");
                }
                shooting = value;
            }
        }

        public double SkillLevel =>
            Math.Round((this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) / StatsCount);

    }
}
