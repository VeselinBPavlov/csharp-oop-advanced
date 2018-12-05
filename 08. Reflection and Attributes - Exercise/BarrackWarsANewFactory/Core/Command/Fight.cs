namespace BarrackWars.Core.Command
{
    using System;

    public class Fight : Command
    {
        public Fight(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
