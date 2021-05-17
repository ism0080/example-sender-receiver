using Example.SenderReceiver.TaskHandlers.Common.Interfaces;

namespace Example.SenderReceiver.PipelineBuilder.Interfaces
{
    public interface IHandlerConfiguration<out TConfiguration> : IBindingInfo
        where TConfiguration : IHandlerConfiguration<TConfiguration>
    {
        string Name { get; set; }
        TConfiguration[] Handlers { get; }
    }
}
