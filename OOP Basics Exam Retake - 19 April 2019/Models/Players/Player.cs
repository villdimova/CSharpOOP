using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
       
        private string username;
        private int health;
        

        protected Player(ICardRepository cardRepository,string username,int health)
        {
            this.CardRepository = cardRepository;
            this.Health = health;
            this.Username = username;
        }
        public ICardRepository CardRepository { get; }
        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }
        public int Health
        {
            get 
            { 
                return this.health; 
            }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }
        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (damagePoints>this.Health)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }

        public override string ToString()
        {
            return String.Format(ConstantMessages.PlayerReportInfo, this.Username, this.Health,this.CardRepository.Count);
        }
    }
}
