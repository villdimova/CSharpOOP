
using System;
using System.Collections.Generic;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var command = Console.ReadLine().Split();
                var firstName = command[0];
                var lastName = command[1];
                var age = int.Parse(command[2]);
                var salary = decimal.Parse(command[3]);

                try
                {
                    Person person = new Person(firstName,lastName, age, salary);
                    persons.Add(person);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
            }

            var parcentage = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(parcentage));
            persons.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
