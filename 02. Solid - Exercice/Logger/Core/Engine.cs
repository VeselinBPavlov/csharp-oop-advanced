namespace Logger.Core
{
    using System;

    using Contracts;

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

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                var data = command.Split('|', StringSplitOptions.RemoveEmptyEntries);

                this.commandInterpreter.AddMessage(data);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}
