using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeam
{
    public class Engine
    {
        private List<Team> teams;

        public Engine()
        {
            this.teams = new List<Team>();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    try
                    {
                        var command = input.Split(";", StringSplitOptions.RemoveEmptyEntries)
                       .ToArray();
                        var commandName = command[0];
                        if (commandName == "Add")
                        {
                            AddPlayerToTeam(command);

                        }
                        else if (commandName == "Team")
                        {
                            var teamName = command[1];
                            Team team = new Team(teamName);
                            teams.Add(team);

                        }
                        else if (commandName == "Remove")
                        {
                            RemovePlayer(command);

                        }
                        else if (commandName == "Rating")
                        {
                            string teamName = command[1];
                            this.ValidateTeamExitst(teamName);
                            Team team = this.teams.First(t => t.Name == teamName);
                            Console.WriteLine(team);


                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

        private void RemovePlayer(string[] command)
        {
            string teamName = command[1];
            string playerName = command[2];
            this.ValidateTeamExitst(teamName);

            Team team = this.teams.FirstOrDefault(t => t.Name == teamName);
            team.RemovePlayer(playerName);
        }

        private void AddPlayerToTeam(string[] command)
        {
            var teamName = command[1];
            this.ValidateTeamExitst(teamName);
            var playerName = command[2];
            Stats stats = CreateStats(command);
            Team team = teams.First(t => t.Name == teamName);
            Player player = new Player(playerName, stats);
            team.AddPlayer(player);
        }

        private void ValidateTeamExitst(string name)
        {
            if (!this.teams.Any(t => t.Name == name))
            {
                throw new ArgumentException($"Team {name} does not exist.");
            }

        }

        private Stats CreateStats(string[] command)
        {
            int endurance = int.Parse(command[3]);
            int sprint = int.Parse(command[4]);
            int dribble = int.Parse(command[5]);
            int passing = int.Parse(command[6]);
            int shooting = int.Parse(command[7]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;

        }
    }


}
