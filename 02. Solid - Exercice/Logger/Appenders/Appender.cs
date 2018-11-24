namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;
        
        public ReportLevel ReportLevel { get; set; }
        public int MessageCount { get; protected set; }
        protected ILayout Layout => this.layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ReportLevel.ToString().ToUpper()},  Messages appended: {this.MessageCount}";
        }
    }
}
