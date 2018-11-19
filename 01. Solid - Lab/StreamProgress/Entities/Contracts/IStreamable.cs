namespace StreamProgress.Entities.Contracts
{
    public interface IStreamable
    {
            int Length { get; }
            int BytesSent { get; }
    }
}
