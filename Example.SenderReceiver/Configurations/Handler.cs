using Example.SenderReceiver.PipelineBuilder.Interfaces;
using System.Collections.Generic;

namespace Example.SenderReceiver.Configurations
{
    public class Handler : IHandlerConfiguration<Handler>
    {
        public string Name { get; set; }
        public List<TaskHandlers.Common.KeyValuePair> Props { get; set; }
        public Handler[] Handlers { get; set; }
    }
}
