﻿using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.Players.Any(p=>p.Username==player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var player = this.players.FirstOrDefault(p => p.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }

           return this.players.Remove(player);
        }
    }
}
