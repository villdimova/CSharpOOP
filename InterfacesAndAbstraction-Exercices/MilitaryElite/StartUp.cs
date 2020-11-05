using System;

namespace MilitaryElite
{
   public class StartUp
    {
       public static void Main(string[] args)
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
