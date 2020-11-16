using LoggerLibrary.Enums;
using LoggerLibrary.Layots;
using LoggerLibrary.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Appenders
{
    public class FileAppender : Appender
    {
        
        public FileAppender(ILayout layout,ILogFile logFile)
            :base(layout)
        {
            
            this.LogFile = logFile;
        }

       
        public ILogFile LogFile { get; }


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.Counter++;
                this.LogFile.Write(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
           
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.LogFile.Size}";
        }
    }
}
    