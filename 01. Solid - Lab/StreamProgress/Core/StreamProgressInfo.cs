namespace StreamProgress
{
    using StreamProgress.Entities.Contracts;

    public class StreamProgressInfo
    {
        private IStreamable stream;

        public IStreamable Stream { get; private set; }

        public StreamProgressInfo(IStreamable stream)
        {
            this.Stream = stream;
        }

        public int CalculateCurrentPercent()
        {
            return (this.Stream.BytesSent * 100) / this.Stream.Length;
        }
    }
}
