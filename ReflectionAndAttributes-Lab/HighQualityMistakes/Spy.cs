using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
       public string  AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] wrongFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            MethodInfo[] wrongGetters= classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo[] wrongSetters = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance );
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in wrongFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in wrongGetters.Where(g=>g.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in wrongSetters.Where(g => g.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

           return sb.ToString().TrimEnd();
        }
    }
}
