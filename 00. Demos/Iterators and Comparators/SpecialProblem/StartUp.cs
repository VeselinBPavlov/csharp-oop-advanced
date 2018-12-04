using System;

namespace SpecialProblem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IWriter writer = new Writer();
            IReader reader = new Reader();
             
            Engine engine = new Engine(writer, reader);
        }
    }
}
