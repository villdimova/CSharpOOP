using System;

namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id,string firstName,string lastName, decimal salary)
            :base(id,firstName,lastName)
        {
            this.Salary = salary;
        }
        public int Id { get;}

        public string FirstName { get;}

        public string LastName { get;}

        public decimal Salary { get;}

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}
