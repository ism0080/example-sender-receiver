using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.SenderReceiver.PipelineBuilder
{
    public class TaskHandlerFactory<TConfig> : ITaskHandlerFactory<TConfig>
        where TConfig : IHandlerConfiguration<TConfig>
    {
        private readonly IEnumerable<ITaskHandler> _handlers;
        private readonly IServiceProvider _sp;

        public TaskHandlerFactory(IEnumerable<ITaskHandler> handlers, IServiceProvider sp = null)
        {
            _handlers = handlers;
            _sp = sp;
        }

        public ITaskHandler Get(IHandlerConfiguration<TConfig> configuration)
        {
            var handlerInstace = _handlers.FirstOrDefault(x => x.Name == configuration.Name);

            if (handlerInstace == null) throw new Exception(configuration.Name);

            var instance = (ITaskHandler)Activator.CreateInstance(handlerInstace.GetType());

            instance.Initialize(configuration);

            ((TaskHandlerBase)instance).SetServiceProvider(_sp);

            return instance;
        }
    }
}
