namespace PetClinic.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private ClinicController clinicController;

        public Engine()
        {
            this.clinicController = new ClinicController();
        }

        public void Run()
        {
            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var data = Console.ReadLine().Split();
                var args = data.Skip(1).ToArray();
                var command = data[0];

                try
                {
                    switch (command)
                    {
                        case "Create": clinicController.Create(args); break;
                        case "Add": Console.WriteLine(clinicController.Add(args)); break;
                        case "Release": Console.WriteLine(clinicController.Release(args)); break;
                        case "HasEmptyRooms": Console.WriteLine(clinicController.HasEmptyRooms(args)); break;
                        case "Print": Console.WriteLine(clinicController.Print(args)); break;
                        default: break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }
        }
    }
}
