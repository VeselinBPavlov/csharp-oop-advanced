namespace Travel.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using Contracts;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
			var itemTypes = Assembly.GetCallingAssembly().GetTypes()
				.Where(t => typeof(IItem).IsAssignableFrom(t) && !t.IsAbstract)
				.ToArray();

			var itemType = itemTypes.FirstOrDefault(t => t.Name == type);

			var item = (IItem)Activator.CreateInstance(itemType);

			return item;
		}
	}
}
