using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System.Threading.Tasks;

namespace Example.SenderReceiver.Tests.Internal.Unit.TestHandlers
{
    public class MessageReceived : TaskHandlerBase, ITaskHandler
    {
        public override string Name { get; } = nameof(MessageReceived);

        public override Task HandleAsync(IMessage message)
        {
            return Task.CompletedTask;
        }
    }
}
