namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            var itemTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(i => typeof(IItem).IsAssignableFrom(i) && !i.IsAbstract)
                .ToArray();

            var itemType = itemTypes.FirstOrDefault(i => i.Name == type);

            var item = (IItem)Activator.CreateInstance(itemType);

            return item;
        }
    }
}
