using System;
using System.Collections.Generic;
using System.Transactions;

namespace Problem01.IEnumerableDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student() { Name = "Gosho" });
            students.Add(new Student() { Name = "Pesho" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });
            students.Add(new Student() { Name = "Kiro" });

            SoftUniCollection softUniCollection = new SoftUniCollection(students);

            foreach (var item in softUniCollection)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
