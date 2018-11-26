namespace GenericCountMethodString
{
    using System;

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

            var comparator = Console.ReadLine();
            
            Console.WriteLine(box.CountGreaterElements(comparator));
        }
    }
}
