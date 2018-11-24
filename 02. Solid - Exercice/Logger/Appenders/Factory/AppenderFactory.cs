namespace Logger.Appenders.Factory
{
    using System;

    using Contracts;
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers;    

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            type = type.ToLower();

            switch (type)
            {
                case "consoleappender": return new ConsoleAppender(layout);
                case "fileappender": return new FileAppender(layout, new LogFile());
                default: throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
