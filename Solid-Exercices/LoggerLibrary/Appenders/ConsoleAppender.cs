using LoggerLibrary.Enums;
using LoggerLibrary.Layots;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Appenders
{
    public class ConsoleAppender : Appender
    {
       
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
           
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel<=reportLevel)
            {
                this.Counter++;
                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
            }
           
        }

        
    }
}
