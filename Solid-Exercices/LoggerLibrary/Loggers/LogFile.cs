namespace LoggerLibrary.Loggers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
        
        public void Write(string message)
        {
            
            File.AppendAllText(LogFilePath, message+Environment.NewLine);
        }

        
        public int Size => File.ReadAllText(LogFilePath)
            .Where(c=>char.IsLetter(c)).Sum(c=>c);

    }
}
