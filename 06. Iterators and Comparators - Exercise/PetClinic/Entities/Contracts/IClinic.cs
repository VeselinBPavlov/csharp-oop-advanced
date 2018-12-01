namespace PetClinic.Entities.Contracts
{
    using System.Collections.Generic;

    public interface IClinic : IEnumerable<IPet>
    {
        string Name { get; }
        int Capacity { get; }

        bool Add(IPet pet);
        bool Release();
        bool HasEmptyRooms();
        string Print(int room);
        string Print();
    }
}
