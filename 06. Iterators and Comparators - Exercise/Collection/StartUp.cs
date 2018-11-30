namespace Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            ListyIterator<string> listyIterator = new ListyIterator<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    var data = command.Split();

                    switch (data[0])
                    {
                        case "Create": listyIterator.Create(data.Skip(1).ToArray()); break;
                        case "Move": Console.WriteLine(listyIterator.Move()); break;
                        case "HasNext": Console.WriteLine(listyIterator.HasNext()); break;
                        case "Print": listyIterator.Print(); break;
                        case "PrintAll": listyIterator.PrintAll(); break;
                        default: break;
                    }
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
