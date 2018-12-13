namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using FestivalManager.Core.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class StartUp
	{
		public static void Main()
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

			IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();

            IFestivalController festivalController = new FestivalController(stage, setFactory, instrumentFactory);
			ISetController setController = new SetController(stage);

			IEngine engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}