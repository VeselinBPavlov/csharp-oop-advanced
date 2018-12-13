namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Text;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IFestivalController festivalCоntroller;
        private ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }

        public void Run()
        {
            string command;
            var sb = new StringBuilder();
            while ((command = reader.ReadLine()) != "END")
            {
                string result;
                try
                {
                    result = this.ProcessCommand(command);
                    sb.AppendLine(result);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        sb.AppendLine("ERROR: " + ex.InnerException.Message);
                    }
                    else
                    {
                        sb.AppendLine("ERROR: " + ex.Message);
                    }
                }
            }

            var report = this.festivalCоntroller.ProduceReport();

            sb.AppendLine("Results:");
            sb.AppendLine(report.Trim());
            this.writer.WriteLine(sb.ToString().TrimEnd());
        }

        public string ProcessCommand(string input)
        {
            var data = input.Split();

            var command = data.First();
            var args = data.Skip(1).ToArray();

            string result;
            if (command == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();              
            }
            else
            {
                var festivalcontrolfunction = this.festivalCоntroller
                .GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == command);

                result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });                
            }

            return result;
        }
    }
}