namespace SpecialProblem
{
    internal class Engine
    {
        private IWriter writer;
        private IReader reader;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            //AddFood
            this.writer.WriteLine("", "");
        }
    }
}