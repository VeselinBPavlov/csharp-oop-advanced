namespace Logger.Appenders
{
    using System;
        
    using Layouts.Contracts;
    using Loggers.Enums;

    public class ConsoleAppender : Appender
    {        
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                Console.WriteLine(this.Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
