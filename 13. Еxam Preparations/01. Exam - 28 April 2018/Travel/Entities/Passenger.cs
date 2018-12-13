namespace Travel.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Passenger : IPassenger
	{
        public string Username { get; }
        public IList<IBag> Bags { get; }

        public Passenger(string username)
		{
			this.Username = username;

			this.Bags = new List<IBag>();
		}
	}
}