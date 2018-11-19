namespace StreamProgress.Core
{
    using StreamProgress.Entities.Contracts;
    using StreamProgress.Entities;
    using System;

    public class Engine
    {
        private StreamProgressInfo streamProgress;

        public void Run()
        {
            IStreamable book = new Book("C# Basics", 30, 40);
            IStreamable song = new Music("Metallica", "Hardwired", 120, 300);

            var bookStreamProgress = CalculateStreamProgress(book);
            var songStreamProgress = CalculateStreamProgress(song);

            Print(book.GetType().Name, bookStreamProgress);
            Print(song.GetType().Name, songStreamProgress);
        }

        private int CalculateStreamProgress(IStreamable stream)
        {
            streamProgress = new StreamProgressInfo(stream);
            return streamProgress.CalculateCurrentPercent();
        }

        private void Print(string type, int streamProgress)
        {
            Console.WriteLine($"{type}: {streamProgress}%");
        }
    }
}
