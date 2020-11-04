using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration
{
    public class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birtdate = birthdate;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birtdate { get; set; }
    }
}
