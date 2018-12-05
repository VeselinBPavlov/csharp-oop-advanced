namespace BarrackWars.Core.Command
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        public string[] Data { get; set; }

        public Command(string[] data)
        {
            this.Data = data;
        }       

        public abstract string Execute();
    }
}
