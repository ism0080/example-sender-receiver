using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Example.SenderReceiver.PipelineConfigurationFactories
{
    public class PipelineConfigurationFromJson : IPipelineConfigurationFactory<Handler>
    {
        private const string pipelineSectionName = "pipelines";
        private readonly string pipelineSourceFilePath;

        public PipelineConfigurationFromJson(IOptions<PipelineSettings> settings)
        {
            pipelineSourceFilePath = settings.Value.SourcePath;
        }

        public Task<IPipelineConfiguration<Handler>[]> GetConfigurationsAsync()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(pipelineSourceFilePath)
                .Build();

            var settings = configuration.GetSection(pipelineSectionName).Get<Pipeline[]>();

            var dd = settings.Select(x => new PipelineConfigurationSection
            {
                Name = x.Name,
                Handlers = x.Handlers.ToArray()
            }).ToArray();

            return Task.FromResult((IPipelineConfiguration<Handler>[])dd);
        }

        internal class PipelineConfigurationSection : IPipelineConfiguration<Handler>
        {
            public string Name { get; set; }
            public IHandlerConfiguration<Handler>[] Handlers { get; set; }
        }
    }
}
