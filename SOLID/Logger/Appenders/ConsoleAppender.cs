namespace Logger.Appenders
{
    using System;

    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    public class ConsoleAppender : IAppender
    {
        private readonly ILayout layout;

        public ReportLevel ReportLevel { get; set; }

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                Console.WriteLine(this.layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
