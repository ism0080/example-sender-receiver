using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Example.SenderReceiver
{
    public class PipelineExecution : BackgroundService
    {
        private readonly ILogger<PipelineExecution> _logger;
        private PipelineBuilder<Handler> Builder { get; }

        public PipelineExecution(PipelineBuilder<Handler>  builder, ILogger<PipelineExecution> logger)
        {
            Builder = builder;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting pipeline execution");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var tasks = (await Builder.BuildAsync()).Select(x => Task.Run(async () => await x.StartAsync(), stoppingToken));
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run the pipeline. Error: {ex.Message}");
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping pipeline execution");
            return base.StopAsync(cancellationToken);
        }
    }
}
