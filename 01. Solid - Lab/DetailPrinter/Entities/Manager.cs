namespace DetailPrinter.Entities
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        public IReadOnlyCollection<string> Documents { get; set; }

        public Manager(string name, ICollection<string> documents) 
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }
        

        public override string ToString()
        {
            return base.ToString() + $"  Documents - {string.Join(", ", this.Documents)}";
        }
    }
}
