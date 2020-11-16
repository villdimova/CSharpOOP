using LoggerLibrary.Appenders;
using LoggerLibrary.Enums;
using LoggerLibrary.Layots;
using LoggerLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Factories
{
    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout,ReportLevel reportLevel)
        {
           
            if (type== "ConsoleAppender")
            {
                return new ConsoleAppender(layout) {ReportLevel=reportLevel};
            }
            else if (type== "FileAppender")
            {
                return new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };
            }

            else
            {
                throw new ArgumentException("Not valid Appender Type!");
            }
        }
    }
}
