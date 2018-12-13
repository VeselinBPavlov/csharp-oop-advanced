namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string typeName)
		{
            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(i => i.Name == typeName);

            IInstrument instrument = (IInstrument)Activator.CreateInstance(type);

            return instrument;
		}
	}
}