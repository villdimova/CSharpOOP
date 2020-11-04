using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizens = new List<IIdentifiable>();
          

            while (true)
            {
                var input = Console.ReadLine();
                if (input== "End")
                {
                    break;
                }
                else
                {
                    var citizenInfo = input.Split().ToArray();
                    if (citizenInfo.Length==2)
                    {
                        Robot robot = new Robot(citizenInfo[0], (citizenInfo[1]));
                        citizens.Add(robot);
                    }
                    else if (citizenInfo.Length == 3)
                    {
                        Citizen citizen = new Citizen(citizenInfo[0], int.Parse(citizenInfo[1]), citizenInfo[2]);
                        
                            citizens.Add(citizen);
                       
                    }
                }
            }
            string rebellionString = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.Id.EndsWith(rebellionString))
                {
                    Console.WriteLine(citizen.Id);
                }
                
            }
        }
    }
}
