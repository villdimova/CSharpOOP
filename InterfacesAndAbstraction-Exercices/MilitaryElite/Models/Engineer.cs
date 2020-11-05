﻿using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps, ICollection<IRepair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public ICollection<IRepair> Repairs {get;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine("  " + item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
