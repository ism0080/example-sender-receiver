using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Example.SenderReceiver.PipelineConfigurationFactories
{
    public class PipelineConfigurationFromLocal : IPipelineConfigurationFactory<Handler>
    {
        public async Task<IPipelineConfiguration<Handler>[]> GetConfigurationsAsync()
        {
            try
            {
                //var pipeLine = await File.ReadAllTextAsync(@"pipeline.json");
                //var pipelines = JsonConvert.DeserializeObject<Pipeline[]>(pipeLine);

                var deserializer = new DeserializerBuilder().WithNamingConvention(PascalCaseNamingConvention.Instance).Build();

                var pipeLine = await File.ReadAllTextAsync(@"pipeline.yml");
                var pipelines = deserializer.Deserialize<Pipeline[]>(pipeLine);

                IPipelineConfiguration<Handler>[] pipelineConfigurations = pipelines.Select(x => 
                    new PipelineConfigurationSection
                    {
                        Name = x.Name,
                        Handlers = x.Handlers.ToArray()
                    }).ToArray();

                Console.WriteLine($"Successfully received configuration from local pipeline.json ");

                return pipelineConfigurations;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get configurations from local 'pipeline.json' ");
                throw;
            }
        }
    }
}
