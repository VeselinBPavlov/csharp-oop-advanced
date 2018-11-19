namespace DetailPrinter.Core
{
    using DetailPrinter.Entities;
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public void Run()
        {
            Employee manager = new Manager("Elon Musk", new List<string>()
            {
                "SpaceX",
                "Tesla",
                "Hyperloop",
                "SolarCity"
            });

            Employee hygienist = new Hygienist("Lelq Vanche", new List<string>()
            {
                "Broom",
                "Paddle",
                "Vacuum Cleaner",
                "Big Mouth"
            });

            var employeeList = new List<Employee>() { manager, hygienist };
            var detailsPrinter = new DetailsPrinter(employeeList);

            Console.WriteLine(detailsPrinter.PrintDetails());;            
        }
    }
}
