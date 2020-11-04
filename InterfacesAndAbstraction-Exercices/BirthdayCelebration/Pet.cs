
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Pet:IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birtdate=birthdate;
        }

       
        public string Name { get; set; }
        public string Birtdate { get; set; }
    }
}
