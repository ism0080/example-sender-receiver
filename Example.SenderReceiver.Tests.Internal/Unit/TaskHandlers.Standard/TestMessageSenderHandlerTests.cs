using Example.SenderReceiver.TaskHandlers.Standard.HelperHandlers;
using Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Example.SenderReceiver.Tests.Internal.Unit.TaskHandlers.Standard
{
    public class TestMessageSenderHandlerTests : PipelineBuilderBase
    {
        [Fact(DisplayName = "TestMessageSenderHandler should successfully Initialize with valid properties")]
        public async Task TestMessageSenderHandlerInitializeSuccessfully()
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory("pipeline_testmessage.json");
            var binddingConfiguration = (await pipelineConfigurationFactory.GetConfigurationsAsync())[0].Handlers[0];
            var handler = new TestMessageSenderHandler();
            handler.Initialize(binddingConfiguration);
            Assert.True(true);
        }

        [Fact(DisplayName =
            "TestMessageSenderHandler should throw PropertyBindingException for missing or invalid properties")]
        public async Task TestMessageSenderHandlerShouldThrowPropertyBindingExceptionForInvalidOrMissingProperty()
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory("pipeline_testmessage.json");
            var bindingConfiguration = (await pipelineConfigurationFactory.GetConfigurationsAsync())[1].Handlers[0];
            var handler = new TestMessageSenderHandler();
            Assert.Throws<Exception>(() => handler.Initialize(bindingConfiguration));
        }
    }
}
