using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {

            var terrorists = players.Where(p => p.GetType().Name
            == nameof(Terrorist)).ToList();

            var counterTerrorists = players.Where(p => p.GetType().Name 
            == nameof(CounterTerrorist)).ToList();
           
           

            while (terrorists.Any(t=>t.IsAlive)&& counterTerrorists.Any(c=>c.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive==false)
                    {
                        continue;
                    }
   
                    foreach (var counterTerroris in counterTerrorists)
                    {
                      
                        if (counterTerroris.IsAlive==false)
                        {
                            continue;

                        }
                        counterTerroris.TakeDamage(terrorist.Gun.Fire());
                    }

                    
                }

                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive==false)
                    {
                        continue;

                    }
                   

                    foreach (var terrorist in terrorists)
                    {
                        
                        if (terrorist.IsAlive==false)
                        {
                            continue;
                        }
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }

                   
                }

               
 
            }

            string result = String.Empty;

            if (terrorists.Any(t=>t.IsAlive))
            {
                result = "Terrorist wins!";
            }
            else
            {
                result ="Counter Terrorist wins!";
            }

            return result;
        }
    }
}
