using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder
{
    public class PipelineBuilderTests : PipelineBuilderBase
    {
        [Fact]
        public async Task ShouldCreatePipelinesFromJson()
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory("pipeline_one_taskhandler.json");
            (await pipelineConfigurationFactory.GetConfigurationsAsync()).Length.ShouldBe(1);
            var taskHandlerFactory = GetTaskHandlerFactory();

            var builder = new PipelineBuilder<Handler>(pipelineConfigurationFactory, taskHandlerFactory);
            var pipelines = await builder.BuildAsync();

            pipelines.Length.ShouldBe(1);
        }

        [Fact]
        public async Task ShouldCreatePipelinesWithMultipleHandlersFromJson()
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory("pipeline_two_taskhandler.json");
            var taskHandlerFactory = GetTaskHandlerFactory();
            var builder = new PipelineBuilder<Handler>(pipelineConfigurationFactory, taskHandlerFactory);
            var pipelines = await builder.BuildAsync();

            pipelines.Length.ShouldBe(1);
        }

        //[Fact(DisplayName = "PipelineBuilder should log PropertyBindingExceptionEvent")]
        //public async Task PipelineBuilderShouldLogPropertyBindingExceptionEvent()
        //{
        //    var pipelineConfigurationFactory = GetPipelineConfigurationFactory();
        //    var bindingConfigurations = (await pipelineConfigurationFactory.GetConfigurationsAsync())[1].Handlers[0];
        //    var taskHandlerFactory = GetTaskHandlerFactory();
        //    var builder = new PipelineBuilder<Handler>(pipelineConfigurationFactory, taskHandlerFactory);
        //    await Assert.ThrowsAsync<PropertyBindingException>(() => builder.BuildAsync());

        //    Mock.Get(emitter).Verify(m =>
        //        m.Raise(
        //            It.Is<IEvent>(arg =>
        //                (arg as PropertyBindingExceptionEvent).BuildProperties()["ServiceBusConnectionString"] ==
        //                "'Service Bus Connection String' must not be empty."), LogLevel.Error, null));
        //}
    }
}
