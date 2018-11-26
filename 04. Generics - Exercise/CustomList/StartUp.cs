namespace CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var customList = new CustomList<string>();

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                var data = command.Split();
                switch (data[0])
                {
                    case "Add": customList.Add(data[1]); break;
                    case "Remove": customList.Remove(int.Parse(data[1])); break;
                    case "Contains": customList.Contains(data[1]); break;
                    case "Swap": customList.Swap(int.Parse(data[1]), int.Parse(data[2])); break;
                    case "Greater": customList.Greater(data[1]); break;
                    case "Max": customList.Max(); break;
                    case "Min": customList.Min(); break;
                    case "Print": customList.Print(); break;
                    default: throw new ArgumentException("Invalid command!");
                }
            }
        }
    }
}
