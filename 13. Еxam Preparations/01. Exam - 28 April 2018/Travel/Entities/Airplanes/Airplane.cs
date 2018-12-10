namespace Travel.Entities.Airplanes
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	using Entities.Contracts;

	public abstract class Airplane : IAirplane
	{
		private readonly List<IBag> bags;

		private readonly List<IPassenger> passengers;

		protected Airplane(int seats, int bagCompartments)
		{
			this.Seats = seats;
			this.BaggageCompartments = bagCompartments;

			this.passengers = new List<IPassenger>();
			this.bags = new List<IBag>();
		}

		public int Seats { get; }

		public int BaggageCompartments { get; }

		public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();

		public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

		public bool IsOverbooked => this.Passengers.Count > Seats;

		public void AddPassenger(IPassenger passenger)
		{
			this.passengers.Add(passenger);
		}

		public IPassenger RemovePassenger(int seat)
		{
			var passenger = this.passengers[seat];

			this.passengers.RemoveAt(seat);

			return passenger;
		}

		public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
		{
			var passengerBags = this.bags
				.Where(b => b.Owner == passenger)
				.ToArray();

			foreach (var bag in passengerBags)
			{
				this.bags.Remove(bag);
			}

			return passengerBags;
		}

		public void LoadBag(IBag bag)
		{
			var isBaggageCompartmentFull = this.BaggageCompartment.Count >= this.BaggageCompartments;
			if (isBaggageCompartmentFull)
			{
				throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
			}

			this.bags.Add(bag);
		}
	}
}