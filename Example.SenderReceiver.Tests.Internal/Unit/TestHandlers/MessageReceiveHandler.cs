using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.SenderReceiver.Tests.Internal.Unit.TestHandlers
{
    public class MessageReceiveHandler : TaskHandlerBase, ITaskHandler
    {
        public List<IMessage> MessagesReceived { get; set; } = new List<IMessage>();
        public override string Name { get; } = nameof(MessageReceiveHandler);

        public override Task HandleAsync(IMessage message)
        {
            MessagesReceived.Add(message);
            return Task.CompletedTask;
        }
    }
}
