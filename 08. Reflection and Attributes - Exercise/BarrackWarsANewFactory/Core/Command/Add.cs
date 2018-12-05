namespace BarrackWars.Core.Command
{
    using Contracts;

    public class Add : Command
    {
        private IUnit unit;

        [Inject]
        public IUnitFactory UnitFactory { get; set; }

        [Inject]
        public IRepository Repository { get; set; }

        public Add(string[] data, IUnitFactory factory, IRepository repository)
            : base(data)
        {
            this.UnitFactory = factory;
            this.Repository = repository;
        }        

        public override string Execute()
        {
            this.unit = this.UnitFactory.CreateUnit(base.Data[1]);
            this.Repository.AddUnit(this.unit);
            string output = base.Data[1] + " added!";
            return output;
        }
    }
}
