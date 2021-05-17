using Example.SenderReceiver.TaskHandlers.Common.Interfaces;

namespace Example.SenderReceiver.TaskHandlers.Common.Messages
{
    public class Message<T> : IMessage
    {
        public T Body { get; }
        public string CorrelationId { get; }
        public object Content => Body;

        public Message(T message, string correlationId = null)
        {
            Body = message;
            CorrelationId = correlationId;
        }

        public void Dispose() { }
    }
}
