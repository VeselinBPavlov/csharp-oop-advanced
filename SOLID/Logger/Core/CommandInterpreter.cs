namespace Logger.Core
{
    using System.Collections.Generic;

    using Contracts;
    using Appenders.Contracts;
    using Appenders.Factory.Contracts;
    using Appenders.Factory;
    using Loggers.Enums;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
        }


        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.Info;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }


        }

        public void AddMessage(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}
