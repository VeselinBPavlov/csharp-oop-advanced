namespace Logger.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Appenders.Contracts;
    using Appenders.Factory.Contracts;
    using Appenders.Factory;
    using Loggers.Enums;    
    using Layouts.Contracts;
    using Layouts.Factory.Contracts;
    using Layouts.Factory;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }


        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = layoutFactory.CreateLayout(layoutType);
            IAppender appender = appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            appenders.Add(appender);

        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            var dateTime = args[1];
            var message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
