using LoggerLibrary.Appenders;
using LoggerLibrary.Enums;
using LoggerLibrary.Factories;
using LoggerLibrary.Layots;
using LoggerLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IAppender> appenders = new List<IAppender>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                var input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string appenderType = input[0];
                string layoutType = input[1];
                ReportLevel reportLevel=ReportLevel.INFO;

                if (input.Length>2)
                {
                    reportLevel = Enum.Parse<ReportLevel>(input[2], ignoreCase: true);
                }

                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());
            while (true)
            {
                string inputInfo = Console.ReadLine();

                if (inputInfo == "END")
                {
                    break;
                }
                else
                {
                    var logInfo = inputInfo.Split("|", StringSplitOptions.RemoveEmptyEntries);
                    string loggerMethodType = logInfo[0];
                    string date = logInfo[1];
                    string message = logInfo[2];

                    if (loggerMethodType=="INFO")
                    {
                        logger.Info(date, message);
                    }
                    else if (loggerMethodType == "WARNING")
                    {
                        logger.Warning(date, message);
                    }
                    else if (loggerMethodType == "ERROR")
                    {
                        logger.Error(date, message);
                    }

                    else if (loggerMethodType == "CRITICAL")
                    {
                        logger.Critical(date, message);
                    }

                    else if (loggerMethodType == "FATAL")
                    {
                        logger.Fatal(date, message);
                    }

                    
                }

  
            }

            Console.WriteLine("Logger info");
            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }
    }
}
