using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder;
using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Example.SenderReceiver.PipelineConfigurationFactories;
using Example.SenderReceiver.TaskHandlers.ModuleLoader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.SenderReceiver.ServiceCollectionsExtensions
{
    public static class ServicesPipelineExtensions
    {
        public static IServiceCollection AddPipelineServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTaskHandlers();
            services.AddSingleton<ITaskHandlerFactory<Handler>, TaskHandlerFactory<Handler>>();
            services.Configure<PipelineSettings>(configuration.GetSection(nameof(PipelineSettings)));
            //services.AddSingleton<IPipelineConfigurationFactory<Handler>, PipelineConfigurationFromS3>();
            services.AddSingleton<IPipelineConfigurationFactory<Handler>, PipelineConfigurationFromLocal>();
            services.AddSingleton<PipelineBuilder<Handler>>();
            return services;
        }
    }
}
