namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System;
    

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
