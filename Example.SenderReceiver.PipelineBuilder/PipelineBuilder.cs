using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.SenderReceiver.PipelineBuilder
{
    public class PipelineBuilder<TConfig> where TConfig : IHandlerConfiguration<TConfig>
    {
        private readonly ITaskHandlerFactory<TConfig> _factory;
        private readonly IPipelineConfigurationFactory<TConfig> _pipelineConfigurationFactory;

        public PipelineBuilder(IPipelineConfigurationFactory<TConfig> pipelineConfigurationFactory, ITaskHandlerFactory<TConfig> factory)
        {
            _pipelineConfigurationFactory = pipelineConfigurationFactory;
            _factory = factory;
        }

        public async Task<IPipeline[]> BuildAsync()
        {
            return (await _pipelineConfigurationFactory.GetConfigurationsAsync()).Select(BuildPipeline).ToArray();
        }

        private IPipeline BuildPipeline(IPipelineConfiguration<TConfig> pipelineConfiguration)
        {
            try
            {
                var taskLists = new List<ITaskHandler>();
                ITaskHandler previousHandler = null;

                foreach (var handler in pipelineConfiguration.Handlers)
                {
                    var handlerInstance = CreateTaskHandler(handler);
                    previousHandler?.AddHandler(handlerInstance);
                    previousHandler = handlerInstance;
                    taskLists.Add(handlerInstance);
                }

                return new Pipeline(pipelineConfiguration.Name, taskLists.ToArray());
            }
            catch (Exception ex)
            {
                // log
                throw;
            }
        }

        private ITaskHandler CreateTaskHandler(IHandlerConfiguration<TConfig> config)
        {
            var handler = _factory.Get(config);
            if (config.Handlers != null && config.Handlers.Any())
            {
                handler.AddHandlers(config.Handlers.Select(s => _factory.Get(s)).ToArray());
                foreach (var childHandler in config.Handlers) CreateTaskHandler(childHandler);
            }

            return handler;
        }

    }
}
