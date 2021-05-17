using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.SenderReceiver.PipelineBuilder
{
    public class Pipeline : IPipeline
    {
        private ITaskHandler[] Handlers { get; }

        public string Name { get; }
        public Pipeline(string name, ITaskHandler[] handlers)
        {
            Name = name;
            Handlers = handlers;
        }

        public async Task StartAsync()
        {
            if (Handlers == null || !Handlers.Any()) return;

            if (Handlers[0] != null)
                await Handlers[0]?.StartAsync();

            Console.WriteLine($"Running pipeline {Name}");
        }
    }
}
