namespace Example.SenderReceiver.PipelineBuilder.Interfaces
{
    public interface IPipelineConfiguration<TConfig> where TConfig : IHandlerConfiguration<TConfig>
    {
        string Name { get; set; }
        IHandlerConfiguration<TConfig>[] Handlers { get; }
    }
}
