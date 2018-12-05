namespace BarrackWars.Core
{
    using Contracts;
    using Factories;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        private CommandFactory factory;

        public CommandInterpreter(IServiceProvider service)
        {
            this.serviceProvider = service;
            this.factory = new CommandFactory();
        }

        public IExecutable InterpretCommand(string[] data)
        {
            return factory.CreateCommand(data, this.serviceProvider);
        }
    }
}
