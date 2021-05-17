using Newtonsoft.Json;

namespace Example.SenderReceiver.TaskHandlers.Common.Messages
{
    public class JsonMessage<T> : Message<T>
    {
        public JsonMessage(T message) : base(message) { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(Body);
        }
    }
}
