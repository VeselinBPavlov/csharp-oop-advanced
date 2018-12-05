namespace BarrackWars.Core.Command
{
    using BarrackWars.Contracts;

    public class Retire : Command
    {
        [Inject]
        public IRepository Repository { get; set; }

        public Retire(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }       

        public override string Execute()
        {
            var unit = this.Data[1];
            this.Repository.RemoveUnit(unit);
            return unit + " retired!";
        }
    }
}
