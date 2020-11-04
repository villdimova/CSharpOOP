using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizens = new List<IBirthable>();


            while (true)
            {
                var input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    var citizenInfo = input.Split().ToArray();

                    if (citizenInfo[0] == "Pet")
                    {
                        Pet pet = new Pet(citizenInfo[1], (citizenInfo[2]));
                        citizens.Add(pet);

                    }

                    else if (citizenInfo[0] == "Citizen")
                    {
                        Citizen citizen = new Citizen(citizenInfo[1], int.Parse(citizenInfo[2]), citizenInfo[3], citizenInfo[4]);

                        citizens.Add(citizen);

                    }
                }
            }
            string birthyear = Console.ReadLine();

            foreach (var citizen in citizens)
            {
                if (citizen.Birtdate.EndsWith(birthyear))
                {
                    Console.WriteLine(citizen.Birtdate);
                }

            }
        }
    }
}

