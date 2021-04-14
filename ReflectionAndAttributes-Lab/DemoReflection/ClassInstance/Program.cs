using System;
using System.Reflection;
using System.Linq;

namespace ClassInstance
{
    class Program
    {
        static void Main(string[] args)
        {

            Type personType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == "Person");
            var instance = Activator.CreateInstance(typeof(Person), "Tervel", "Dimov") as Person;


            //Invoke Method
            var eatMethod = typeof(Person).GetMethod("Eat");
            var eatResult = eatMethod.Invoke(instance, new object[] { "Cake" });
            Console.WriteLine(eatResult);


            //Work with get and set


            var propertyFirstName = personType.GetProperty("FirstName");
            var propertyLastName = personType.GetProperty("LastName");
            var nameValue = propertyFirstName.GetValue(instance) as string + " " + propertyLastName.GetValue(instance) as string;
            Console.WriteLine(nameValue);

            propertyFirstName.SetValue(instance, "Aleksander");
            nameValue= propertyFirstName.GetValue(instance) as string + " " + propertyLastName.GetValue(instance);
            Console.WriteLine(nameValue);







        }
    }
}
