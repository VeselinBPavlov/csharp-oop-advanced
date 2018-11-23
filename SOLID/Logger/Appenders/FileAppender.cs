namespace Logger.Appenders
{
    using System.IO;

    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;
    using Loggers.Contracts;

    public class FileAppender : IAppender
    {
        private const string filepath = "log.txt";

        private readonly ILayout layout;
        private readonly ILogFile logFile;

        public ReportLevel ReportLevel { get; set; }

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.layout = layout;
            this.logFile = logFile;
        }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                var contetnt = string.Format(this.layout.Format, dateTime, reportLevel, message) + "\n";
                File.AppendAllText(filepath, contetnt);
            }
        }
    }
}
