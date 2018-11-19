namespace DetailPrinter.Core
{
    using DetailPrinter.Entities;
    using System.Collections.Generic;
    using System.Text;

    public class DetailsPrinter
    {
        private List<Employee> employees;

        public IReadOnlyCollection<Employee> Employees => this.employees.AsReadOnly();

        public DetailsPrinter(List<Employee> employees)
        {
            this.employees = new List<Employee>(employees);
        }

        public string PrintDetails()
        {
            var sb = new StringBuilder();
            foreach (Employee employee in this.employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
