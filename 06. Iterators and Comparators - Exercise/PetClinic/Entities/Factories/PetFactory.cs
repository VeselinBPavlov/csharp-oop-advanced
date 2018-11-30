namespace PetClinic.Entities.Factories
{
    using Contracts;

    public class PetFactory
    {
        public IPet CreatePet(string name, int age, string kind)
        {
            return new Pet(name, age, kind);
        }
    }
}
