using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInstance
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private string country;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Person(string firstName, string lastName, int age, string country)
        {
            this.FirstName = firstName;
            this.LastName = LastName;
            this.Age = age;
            this.Country = Country;
        }


        protected Person()
        {

        }
        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Not valid value");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Not valid value");
                }
                this.lastName = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                if (this.Age <= 0)
                {
                    throw new ArgumentException("Not valid value");
                }
                this.age = value;
            }
        }
        public string Country
        {
            get { return this.country; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Not valid value");
                }
                this.country = value;
            }
        }



        public string WhoAmI()
        {
            return ($"I am {this.FirstName} {this.LastName} {this.Age} age old from {this.Country}");
        }

        public string Eat(string food)
        {
            return ($"{this.FirstName} eats {food}.");
        }
    }
}
