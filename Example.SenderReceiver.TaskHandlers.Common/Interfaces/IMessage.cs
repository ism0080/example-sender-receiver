namespace Example.SenderReceiver.TaskHandlers.Common.Interfaces
{
    public interface IMessage
    {
        object Content { get; }
        string CorrelationId { get; }
    }
}
