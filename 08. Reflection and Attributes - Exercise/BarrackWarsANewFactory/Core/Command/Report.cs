namespace BarrackWars.Core.Command
{
    using BarrackWars.Contracts;

    public class Report : Command
    {
        [Inject]
        public IRepository Repository { get; set; }

        public Report(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }       

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
