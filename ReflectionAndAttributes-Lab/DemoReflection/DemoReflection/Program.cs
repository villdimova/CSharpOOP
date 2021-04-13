using System;
using System.Reflection;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type personType= typeof(Person);

            FieldInfo privateField = personType.GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(privateField.ToString());

            FieldInfo[] privateFields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in privateFields)
            {
                Console.WriteLine($"{field.ToString()}");
            }

            MethodInfo whoAmI = personType.GetMethod("WhoAmI", BindingFlags.Public | BindingFlags.Instance);


            Console.WriteLine(whoAmI.ToString());

            MethodInfo[] methods = personType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.ToString());
            }

            ConstructorInfo constructorInfo = personType.GetConstructor(new[] { typeof(string), typeof(string), typeof(int), typeof(string) });

            Console.WriteLine(constructorInfo);

            ConstructorInfo protectedCtorInfo = personType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,

                null,
                new Type[] { },
                null);

            Console.WriteLine(protectedCtorInfo);

        }
    }
}
