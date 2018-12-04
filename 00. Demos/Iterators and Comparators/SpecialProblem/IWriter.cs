using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialProblem
{
    public interface IWriter
    {
        void Write(string item);

        void Write(decimal price, params string[] items);

        void WriteLine(params string[] items);
    }
}
