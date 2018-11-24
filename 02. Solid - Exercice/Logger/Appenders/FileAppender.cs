namespace Logger.Appenders
{
    using System.IO;
        
    using Layouts.Contracts;
    using Loggers.Enums;
    using Loggers.Contracts;

    public class FileAppender : Appender
    {
        private const string filepath = "log.txt";
      
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) 
            :base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                var contetnt = string.Format(this.Layout.Format, dateTime, reportLevel, message) + "\n";
                this.logFile.Write(contetnt);
                File.AppendAllText(filepath, contetnt);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", {this.logFile.Size}";
        }
    }
}
