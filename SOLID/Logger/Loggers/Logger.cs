namespace Logger.Loggers
{
    using Appenders.Contracts;
    using Contracts;
    using Enums;

    public class Logger : ILogger
    {
        private readonly IAppender consoleAppender;
        private readonly IAppender fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;
        }


        public Logger(IAppender consoleAppender, IAppender fileAppender) 
            : this(consoleAppender)
        {            
            this.fileAppender = fileAppender;
        }


        public void Info(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.Info, infoMessage);
        }

        public void Warning(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.Warning, infoMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.Error, errorMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.Critical, criticalMessage);
        }     

        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.Fatal, fatalMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.fileAppender?.Append(dateTime, reportLevel, message);
            this.consoleAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
