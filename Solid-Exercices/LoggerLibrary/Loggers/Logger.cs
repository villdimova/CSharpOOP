using LoggerLibrary.Appenders;
using LoggerLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;
       

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get { return this.appenders; }
            private set
            {
                if (value==null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "value can not be null");
                }
                this.appenders = value;
            }
        }

       
        public void Error(string dateTime, string message)
        {

            Append(dateTime, ReportLevel.ERROR, message);

        }

        
        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.INFO, message);

        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.FATAL, message);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.CRITICAL, message);

        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.WARNING, message);

        }



        public void Append(string dateTime, ReportLevel error,string  message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
