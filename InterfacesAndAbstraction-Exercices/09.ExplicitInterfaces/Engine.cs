namespace ExplicitInterfaces
{
    using ExplicitInterfaces.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {

            List<Citizen> citizens = new List<Citizen>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                else
                {
                    var citizenInfo = input.Split().ToArray();
                    Citizen citizen = new Citizen(citizenInfo[0], citizenInfo[1], int.Parse(citizenInfo[2]));
                    citizens.Add(citizen);

                }
            }

            foreach (var citizen in citizens)
            {
                IResident resident = citizen;
                IPerson person = citizen;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }

        }


    }
}
