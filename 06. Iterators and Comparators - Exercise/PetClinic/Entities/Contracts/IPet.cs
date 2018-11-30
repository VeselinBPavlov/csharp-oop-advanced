namespace PetClinic.Entities.Contracts
{
    public interface IPet
    {
        string Name { get; }
        int Age { get; }
        string Kind { get; }
    }
}
