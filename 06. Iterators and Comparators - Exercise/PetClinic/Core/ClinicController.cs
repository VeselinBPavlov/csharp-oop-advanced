namespace PetClinic.Core
{
    using System;
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

        public void Create(string[] args)
        {
            var name = args[1];
            var ageOrCapacity = int.Parse(args[2]);

            if (args.Length == 4)
            {
                var kind = args[3];
                IPet pet = petFactory.CreatePet(name, ageOrCapacity, kind);
                this.pets.Add(pet);                
            }
            else
            {
                IClinic clinic = clinicFactory.CreateClinic(name, ageOrCapacity);
                this.clinics.Add(clinic);
            }          
        }

        public bool Release(string[] args)
        {
            var clinicName = args[0];
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

            return clinic.Release();
        }

        public bool Add(string[] args)
        {
            var petName = args[0];
            var clinicName = args[1];
            var pet = this.pets.FirstOrDefault(c => c.Name == petName);
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

            return clinic.Add(pet);
        }

        public string Print(string[] args)
        {
            var clinicName = args[0];
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);
            
            if (args.Length == 2)
            {
                var index = int.Parse(args[1]);
                return clinic.Print(index);
            }
            else
            {
                return clinic.Print();
            }            
        }

        public bool HasEmptyRooms(string[] args)
        {
            var clinicName = args[0];
            var clinic = this.clinics.FirstOrDefault(c => c.Name == clinicName);

            return clinic.HasEmptyRooms();
        }
    }
}
