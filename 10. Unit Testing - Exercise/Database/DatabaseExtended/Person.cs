namespace DatabaseExtended
{
    public class Person
    {
        public string Name { get; set; }
        public long Id { get; set; }

        public Person(string name, long id)
        {
            Name = name;
            Id = id;
        }
    }
}
