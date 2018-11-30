namespace PetClinic.Entities.Factories
{
    using Contracts;

    public class ClinicFactory
    {
        public IClinic CreateClinic(string name, int capacity)
        {
            return new Clinic(name, capacity);
        }
    }
}
