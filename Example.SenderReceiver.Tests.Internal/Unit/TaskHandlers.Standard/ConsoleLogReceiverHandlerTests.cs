using Example.SenderReceiver.TaskHandlers.Standard.HelperHandlers;
using Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder;
using System.Threading.Tasks;
using Xunit;

namespace Example.SenderReceiver.Tests.Internal.Unit.TaskHandlers.Standard
{
    public class ConsoleLogReceiverHandlerTests : PipelineBuilderBase
    {
        [Fact(DisplayName = "ConsoleLogReceiverHandler should successfully Initialize with valid properties")]
        public async Task ConsoleLogReceiverHandlerInitializeSuccessfully()
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory("pipeline_consolelog.json");
            var binddingConfiguration = (await pipelineConfigurationFactory.GetConfigurationsAsync())[0].Handlers[0];
            var handler = new ConsoleLogReceiverHandler();
            handler.Initialize(binddingConfiguration);
            Assert.True(true);
        }
    }
}
