using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using Example.SenderReceiver.TaskHandlers.Common.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace Example.SenderReceiver.Tests.Internal.Unit.TestHandlers
{
    public class MessageGeneratorHandler : TaskHandlerBase, ITaskHandler
    {
        public override string Name { get; } = nameof(MessageGeneratorHandler);

        public override async Task StartAsync()
        {
            foreach (var item in Enumerable.Range(0, 2))
            {
                var message = new Message<int>(item);
                await InvokeNext(message);
            }
        }
    }
}
