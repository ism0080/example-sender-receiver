using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder.Interfaces;

namespace Example.SenderReceiver.PipelineConfigurationFactories
{
    public class PipelineConfigurationSection : IPipelineConfiguration<Handler>
    {
        public string Name { get; set; }
        public IHandlerConfiguration<Handler>[] Handlers { get; set; }
    }
}
