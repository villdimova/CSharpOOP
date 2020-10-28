

using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
       
        private string name;
        private string gender;
        private int age;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
           private set
            {

                if (value<0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public  string Gender
        {
            get 
            {
                return this.gender;
            }
           protected set
            {
                if (value!="Male"&&value!="Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
