using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialProblem
{
    public class Reader : IReader
    {
        public int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }

        public string ReadString()
        {
            return Console.ReadLine();
        }
    }
}
