namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalController;
        private ISetController setController;

        public Engine(
            IReader reader,
            IWriter writer,
            IFestivalController festivalController,
            ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string result;

                try
                {
                    result = this.DoCommand(input);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        result = "ERROR: " + ex.InnerException.Message;
                    }
                    else
                    {
                        result = "ERROR: " + ex.Message;
                    }
                }

                this.writer.WriteLine(result.Trim());
            }

            string report = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(report.Trim());
        }

        private string DoCommand(string input)
        {
            string[] tokens = input.Split();

            string command = tokens[0];

            string result;
            if (command == "LetsRock")
            {
                result = this.setController.PerformSets();
            }
            else
            {
                string[] commandParams = tokens
                    .Skip(1)
                    .ToArray();

                var festivalcontrolfunction = this.festivalController.GetType()
                    .GetMethods()
                    .FirstOrDefault(m => m.Name == command);

                result = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { commandParams });
            }

            return result;
        }
    }
}