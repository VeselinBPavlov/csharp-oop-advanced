namespace PetClinic.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Entities.Contracts;
    using Entities.Factories;    

    public class ClinicController
    {
        private IList<IClinic> clinics;
        private IList<IPet> pets;
        private ClinicFactory clinicFactory;
        private PetFactory petFactory;

        public ClinicController()
        {
            this.clinics = new List<IClinic>();
            this.pets = new List<IPet>();
            this.clinicFactory = new ClinicFactory();
            this.petFactory = new PetFactory();
        }

        public void CreatePet(string name, int age, string kind)
        {
            IPet pet = petFactory.CreatePet(name, age, kind);
            this.pets.Add(pet);
        }

        public void CreateClinic(string name, int capacity)
        {
            IClinic clinic = clinicFactory.CreateClinic(name, capacity);
            this.clinics.Add(clinic);
        }

        public bool Release(string clinicName)
        {
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            return clinic.Release();
        }

        public bool Add(string petName, string clinicName)
        {
            var pet = this.pets.FirstOrDefault(c => c.Name == petName);
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

            return clinic.Add(pet);
        }

        public string Print(string clinicName)
        {
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            return clinic.Print();
        }

        public string Print(string clinicName, int room)
        {
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            return clinic.Print(room);
        }

        public bool HasEmptyRooms(string clinicName)
        {
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            return clinic.HasEmptyRooms();
        }
    }
}
