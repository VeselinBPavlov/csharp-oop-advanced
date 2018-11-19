namespace DetailPrinter.Entities
{
    using System.Collections.Generic;

    public class Hygienist : Employee
    {
        public IReadOnlyCollection<string> Instruments { get; set; }

        public Hygienist(string name, ICollection<string> instruments) 
            : base(name)
        {
            this.Instruments = new List<string>(instruments);
        }

        public override string ToString()
        {
            return base.ToString() + $"  Instruments - {string.Join(", ", this.Instruments)}";
        }
    }
}
