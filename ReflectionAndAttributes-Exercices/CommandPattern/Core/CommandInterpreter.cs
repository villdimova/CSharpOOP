using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (inputArgs[0] + "Command").ToLower();
            string[] commandArgs = inputArgs.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(n => n.Name.ToLower() == commandName);

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

           
            var instance = Activator.CreateInstance(commandType) as ICommand;
            if (instance == null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            string result = instance.Execute(commandArgs);
            return result;
        }
    }
}
