namespace Logger.Appenders.Contracts
{
    using Loggers.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessageCount { get; }

        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}
