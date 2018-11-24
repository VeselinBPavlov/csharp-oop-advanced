namespace Logger.Appenders.Factory.Contracts
{
    using Layouts.Contracts;
    using Appenders.Contracts;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
