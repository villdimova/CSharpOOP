using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
       

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birtdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birtdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
           return  this.Food += 10;
        }
    }
}


