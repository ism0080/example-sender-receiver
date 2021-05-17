using System.Threading.Tasks;

namespace Example.SenderReceiver.PipelineBuilder.Interfaces
{
    public interface IPipelineConfigurationFactory<TConfig> where TConfig : IHandlerConfiguration<TConfig>
    {
        Task<IPipelineConfiguration<TConfig>[]> GetConfigurationsAsync();
    }
}
