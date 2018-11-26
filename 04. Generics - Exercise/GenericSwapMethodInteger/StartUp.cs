namespace GenericSwapMethodInteger
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                box.Items.Add(input);
            }

            var swap = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            box.SwapItems(swap[0], swap[1]);

            Console.WriteLine(box);
        }
    }
}
