namespace Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var personArgs = Console.ReadLine().Split();
            var personInfo = new Threeuple<string, string, string>($"{personArgs[0]} {personArgs[1]}", personArgs[2], personArgs[3]);
            var drinkingArgs = Console.ReadLine().Split();
            if (drinkingArgs[2] == "drunk")
            {
                drinkingArgs[2] = "True";
            }
            else
            {
                drinkingArgs[2] = "False";
            }
            var drunkStatus = new Threeuple<string, int, string>(drinkingArgs[0], int.Parse(drinkingArgs[1]), drinkingArgs[2]);
            var bankInfoArgs = Console.ReadLine().Split();
            var bankInfo = new Threeuple<string, double, string>(bankInfoArgs[0], double.Parse(bankInfoArgs[1]), bankInfoArgs[2]);

            Console.WriteLine(personInfo);
            Console.WriteLine(drunkStatus);
            Console.WriteLine(bankInfo);
        }
    }
}
