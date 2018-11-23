namespace Logger.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Appenders.Contracts;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine().Split();
                commandInterpreter.AddAppender(inputArgs);
            }

        }
    }
}
