namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "Pop")
                {
                    if (stack.Count == 0)
                    {
                        Print("No elements");
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    var tokens = input
                        .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray();

                    foreach (var token in tokens)
                    {
                        stack.Push(token);
                    }
                }
            }
            Iterate(stack);
            Iterate(stack);
        }

        static void Iterate<U>(Stack<U> stack)
        {
            foreach (var item in stack)
            {
                Print(item);
            }
        }

        static void Print<U>(U item)
        {
            Console.WriteLine(item);
        }
    }
}
