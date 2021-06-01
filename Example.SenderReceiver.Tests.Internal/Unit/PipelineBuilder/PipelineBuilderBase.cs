using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder;
using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Example.SenderReceiver.PipelineConfigurationFactories;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using Example.SenderReceiver.TaskHandlers.ModuleLoader;
using Example.SenderReceiver.Tests.Internal.Unit.TestHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;

namespace Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder
{
    public abstract class PipelineBuilderBase
    {
        protected IPipelineConfigurationFactory<Handler> GetPipelineConfigurationFactory(string pipelineFile)
        {
            var settings = Mock.Of<IOptions<PipelineSettings>>();
            Mock.Get(settings).Setup(o => o.Value).Returns(new PipelineSettings { SourcePath = pipelineFile });
            return new PipelineConfigurationFromJson(settings);
        }

        protected TaskHandlerFactory<Handler> GetTaskHandlerFactory()
        {
            IServiceCollection provider = new ServiceCollection();
            provider.AddTaskHandlers();
            provider.AddSingleton<ITaskHandlerFactory<Handler>, TaskHandlerFactory<Handler>>();
            provider.AddScoped<ITaskHandler, MessageGeneratorHandler>();
            provider.AddScoped<ITaskHandler, MessageReceiveHandler>();

            var sp = provider.BuildServiceProvider();

            // This will succeed.
            var fooService = sp.GetService<ITaskHandlerFactory<Handler>>();

            return (TaskHandlerFactory<Handler>)fooService;
        }

        protected async Task<Tuple<T, IHandlerConfiguration<Handler>, ITaskHandler>>
            CreateGeneratorAndReceiverHandlers<T>(string pipeLineFileName, int pipelineIndex, int handlerIndex)
            where T : ITaskHandler
        {
            var pipelineConfigurationFactory = GetPipelineConfigurationFactory(pipeLineFileName);
            var bindingConfiguration = (await pipelineConfigurationFactory.GetConfigurationsAsync())[pipelineIndex]
                .Handlers[handlerIndex];
            var generator = Activator.CreateInstance<T>();
            var handler = Mock.Of<ITaskHandler>();
            generator.AddHandler(handler);
            return new Tuple<T, IHandlerConfiguration<Handler>, ITaskHandler>(generator, bindingConfiguration, handler);
        }
    }
}
