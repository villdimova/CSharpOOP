using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
   public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            Type classType = Type.GetType(className);
            var baseClassName = classType.BaseType;
            sb.AppendLine($"Base Class: {baseClassName.Name}");
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic| BindingFlags.Instance);
            foreach (MethodInfo method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
