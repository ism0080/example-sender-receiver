using Example.SenderReceiver.TaskHandlers.Common.Interfaces;

namespace Example.SenderReceiver.PipelineBuilder.Interfaces
{
    public interface ITaskHandlerFactory<in TConfig> where TConfig : IHandlerConfiguration<TConfig>
    {
        ITaskHandler Get(IHandlerConfiguration<TConfig> configuration);
    }
}
