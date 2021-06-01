using System.Threading.Tasks;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using Example.SenderReceiver.Tests.Internal.Unit.TestHandlers;
using Shouldly;
using Xunit;

namespace Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder
{
    public class TaskHandlerTests : PipelineBuilderBase
    {
        [Fact]
        public async Task TaskHandlerShouldInvokeNextHanlder()
        {
            var taskHandler = new MessageGeneratorHandler() as ITaskHandler;
            taskHandler.Initialize(null);
            var receiver = new MessageReceiveHandler();
            taskHandler.AddHandler(receiver);
            await taskHandler.StartAsync();
            receiver.MessagesReceived.Count.ShouldBe(2);
        }

        [Fact]
        public async Task TaskHandlerShouldNotThrowExceptionWhenThereAreNoNextHandlers()
        {
            var taskHandler = new MessageGeneratorHandler() as ITaskHandler;
            taskHandler.Initialize(null);
            await taskHandler.StartAsync();
            Assert.True(true);
        }

        [Fact]
        public async Task TaskHandlerWithMultipleChildrenHandlers()
        {
            var taskHandler = new MessageGeneratorHandler() as ITaskHandler;
            taskHandler.Initialize(null);
            var receiver_one = new MessageReceiveHandler();
            var receiver_two = new MessageReceiveHandler();
            taskHandler.AddHandlers(new[] { receiver_one, receiver_two });
            await taskHandler.StartAsync();
            receiver_one.MessagesReceived.Count.ShouldBe(2);
            receiver_two.MessagesReceived.Count.ShouldBe(2);
        }
    }
}
