namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";

        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IInstrumentFactory instrumentFactory;

        public FestivalController(
            IStage stage,
            ISetFactory setFactory,
            IInstrumentFactory instrumentFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            string result = $"Registered {type} set";
            return result;
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            string[] instrumentsNames = args.Skip(2).ToArray();

            var instrumenti2 = instrumentsNames
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = new Performer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            string result = $"Registered performer {performer.Name}";
            return result;
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            TimeSpan duration = TimeSpan.ParseExact(args[1], TimeFormat, null);

            ISong song = new Song(name, duration);

            this.stage.AddSong(song);

            string result = $"Registered song {name} ({duration:mm\\:ss})";
            return result;
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            if (set == null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (song == null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            set.AddSong(song);

            string result = $"Added {song.Name} ({song.Duration:mm\\:ss}) to {set.Name}";
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

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            string result = $"Added {performer.Name} to {set.Name}";
            return result;
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

            string result = $"Repaired {instrumentsToRepair.Length} instruments";
            return result;
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

        private string GetRightFormat(TimeSpan timeSpan)
        {
            int minutes = timeSpan.Minutes + timeSpan.Hours * 60;
            int seconds = timeSpan.Seconds;

            string result = $"{minutes:d2}:{seconds:d2}";
            return result;
        }
    }
}