namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
        private ISetFactory setFactory;
        private IInstrumentFactory instrumentFactory;

        private readonly IStage stage;

		public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
		}

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var typeName = args[1];
            var set = this.setFactory.CreateSet(name, typeName);

            stage.AddSet(set);
            return $"Registered {set.GetType().Name} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsNames = args.Skip(2).ToArray();

            var instruments = instrumentsNames
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = new Performer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, null);

            ISong song = new Song(name, duration);

            this.stage.AddSong(song);
            
            return $"Registered song {name} ({duration:mm\\:ss})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        public string ProduceReport()
		{
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {this.GetRightFormat(totalFestivalLength)}") + Environment.NewLine;

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({this.GetRightFormat(set.ActualDuration)}):") + Environment.NewLine;

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + Environment.NewLine;
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + Environment.NewLine;
                else
                {
                    result += ("--Songs played:") + Environment.NewLine;
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + Environment.NewLine;
                    }
                }
            }

            return result;
        }			

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			IPerformer performer = this.stage.GetPerformer(performerName);
			ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        private string GetRightFormat(TimeSpan timeSpan)
        {
            int minutes = timeSpan.Minutes + timeSpan.Hours * 60;
            int seconds = timeSpan.Seconds;

            string result = $"{minutes:d2}:{seconds:d2}";
            return result;
        }
    }
}