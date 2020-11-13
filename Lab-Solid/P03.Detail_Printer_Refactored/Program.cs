using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Program
    {
        public static void Main()
        {
            List <Employee> employees= new List<Employee>();

            List<string> documents = new List<string>();
            string salaries = "Salaries";
            string budget = "Budget";
            documents.Add(salaries);
            documents.Add(budget);

            Manager manager = new Manager("Dimitrov", documents);
            Worker worker = new Worker("Ivanov");

            employees.Add(manager);
            employees.Add(worker);

            foreach (var person in employees)
            {
                Console.WriteLine(person.Print());
            }

        }
    }
}
