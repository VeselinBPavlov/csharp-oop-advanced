using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialProblem
{
    public class Writer : IWriter
    {
        public void Write(string item)
        {
            Console.Write(item);
        }

        public void Write(params string[] items)
        {
            Console.Write(string.Join(" ", items));
        }

        public void WriteLine(params string[] items)
        {
            Console.WriteLine(string.Join(" ", items));
        }
    }
}
