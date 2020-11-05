using System;
using System.Collections.Generic;

namespace MilitaryElite
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private Dictionary<int,ISoldier> soldiers;

        public CommandInterpreter()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        //Private 1 Pesho Peshev 22.22
        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier= null; 
            if (soldierType=="Private")
            {
                decimal salary = decimal.Parse(args[4]);
                 soldier = new Private(id, firstName, lastName, salary);
                this.soldiers.Add(id,soldier);
                return soldier.ToString();
            }
            else if (soldierType== "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(args[4]);
                Dictionary<int, IPrivate> privates = new Dictionary<int, IPrivate>();
                for (int i = 5; i < args.Length; i++)
                {
                    int soldierId = int.Parse(args[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);

                }
                soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
            }

            return soldier.ToString();
        }
    }
}
