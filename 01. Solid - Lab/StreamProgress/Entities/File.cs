namespace StreamProgress.Entities
{
    using StreamProgress.Entities.Contracts;

    public class Book : IStreamable
    {
        private string title;

        public Book(string title, int length, int bytesSent)
        {
            this.title = title;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }
    }
}
