namespace Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var personInfo = Console.ReadLine().Split();
            var namesTuple = new Tuple<string, string>($"{personInfo[0]} {personInfo[1]}", personInfo[2]);
            var beersInfo = Console.ReadLine().Split();
            var beersTuple = new Tuple<string, int>(beersInfo[0], int.Parse(beersInfo[1]));
            var numbers = Console.ReadLine().Split();
            var numsTuple = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

            Console.WriteLine(namesTuple);
            Console.WriteLine(beersTuple);
            Console.WriteLine(numsTuple);
        }
    }
}
