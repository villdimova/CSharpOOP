using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
   public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            var classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance| BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            

            foreach (MethodInfo method in methods.Where(g => g.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in methods.Where(g => g.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
