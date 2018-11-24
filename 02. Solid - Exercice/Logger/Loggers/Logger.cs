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
            AppendMessage(dateTime, ReportLevel.INFO, infoMessage);
        }

        public void Warning(string dateTime, string infoMessage)
        {
            AppendMessage(dateTime, ReportLevel.WARNING, infoMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            AppendMessage(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            AppendMessage(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }     

        public void Fatal(string dateTime, string fatalMessage)
        {
            AppendMessage(dateTime, ReportLevel.FATAL, fatalMessage);
        }

        private void AppendMessage(string dateTime, ReportLevel reportLevel, string message)
        {
            this.fileAppender?.Append(dateTime, reportLevel, message);
            this.consoleAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
