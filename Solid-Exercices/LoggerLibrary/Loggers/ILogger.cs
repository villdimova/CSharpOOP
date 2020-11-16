using LoggerLibrary.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }

        public void Error(string dateTime, string mnessage);

        public void Info(string dateTime, string message);

        public void Fatal(string dateTime, string message);

        public void Critical(string dateTime, string message);

        public void Warning(string dateTime, string message);
    }
}
