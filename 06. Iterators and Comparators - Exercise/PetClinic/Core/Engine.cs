namespace PetClinic.Core
{
    using System;
    using System.Collections.Generic;
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

                var command = data[0];
                try
                {
                    switch (command)
                    {
                        case "Create":
                            {
                                if (data[1] == "Pet")
                                {
                                    clinicController.CreatePet(data[2], int.Parse(data[3]), data[4]);
                                }
                                else
                                {
                                    clinicController.CreateClinic(data[2], int.Parse(data[3]));
                                }
                            }
                            break;
                        case "Add": Console.WriteLine(clinicController.Add(data[1], data[2])); break;
                        case "Release": Console.WriteLine(clinicController.Release(data[1])); break;
                        case "HasEmptyRooms": Console.WriteLine(clinicController.HasEmptyRooms(data[1])); break;
                        case "Print":
                            {
                                if (data.Length == 3)
                                {
                                    Console.WriteLine(clinicController.Print(data[1], int.Parse(data[2])));
                                }
                                else
                                {
                                    Console.WriteLine(clinicController.Print(data[1]));
                                }
                            }
                            break;
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
