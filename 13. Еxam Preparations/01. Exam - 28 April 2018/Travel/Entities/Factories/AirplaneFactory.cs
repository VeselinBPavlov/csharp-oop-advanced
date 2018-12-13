namespace Travel.Entities.Factories
{
    using Contracts;
    using Airplanes.Contracts;
    using System.Reflection;
    using System.Linq;
    using System;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string type)
        {
            var airplaneTypes = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => typeof(IAirplane).IsAssignableFrom(t) && !t.IsAbstract)
                .ToArray();

            var airplaneType = airplaneTypes.FirstOrDefault(t => t.Name == type);

            var airplane = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplane;
        }
    }
}