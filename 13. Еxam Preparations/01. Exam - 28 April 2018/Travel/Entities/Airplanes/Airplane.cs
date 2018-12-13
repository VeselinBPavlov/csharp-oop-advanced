namespace Travel.Entities.Airplanes
{
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IBag> bags;
        private readonly List<IPassenger> passengers;

        public int Seats { get; private set; }
        public int BaggageCompartments { get; private set; }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
        public bool IsOverbooked => this.Passengers.Count() > this.Seats;

        protected Airplane(int seats, int bagCompartments)
        {
            this.Seats = seats;
            this.BaggageCompartments = bagCompartments;

            this.passengers = new List<IPassenger>();
            this.bags = new List<IBag>();
        }
        
        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int index)
        {
            var passanger = this.passengers[index];
            this.passengers.RemoveAt(index);            

            return passanger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
                this.bags.Remove(bag);

            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;
            if (isBaggageCompartmentFull)
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");

            this.bags.Add(bag);
        }
    }
}