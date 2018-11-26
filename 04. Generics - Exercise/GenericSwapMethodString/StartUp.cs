namespace GenericSwapMethodString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var box = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();                
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
