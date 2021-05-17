using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace Example.SenderReceiver.TaskHandlers.Standard.HelperHandlers
{
    public class ConsoleLogReceiverHandler : TaskHandlerBase, ITaskHandler
    {
        public override string Name { get; } = nameof(ConsoleLogReceiverHandler);

        public override Task HandleAsync(IMessage message)
        {
            Console.WriteLine(message.Content);
            return Task.CompletedTask;
        }
    }
}
