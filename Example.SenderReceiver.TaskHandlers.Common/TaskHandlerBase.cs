using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.SenderReceiver.TaskHandlers.Common
{
    public abstract class TaskHandlerBase : ITaskHandler
    {
        protected List<ITaskHandler> _handlers;
        protected IBindingInfo Configuration { get; set; }
        protected IServiceProvider Sp { get; set; }
        protected T ResolveDependacy<T>() => (T)Sp.GetService(typeof(T));

        public abstract string Name { get; }

        protected TaskHandlerBase()
        {
            _handlers = new List<ITaskHandler>();
        }

        public virtual void Initialize(IBindingInfo configuration)
        {
            Configuration = configuration;
        }

        public virtual void SetServiceProvider(IServiceProvider sp)
        {
            Sp = sp;
        }

        public virtual Task HandleAsync(IMessage message)
        {
            return Task.CompletedTask;
        }

        public virtual Task StartAsync()
        {
            return Task.CompletedTask;
        }

        public virtual void AddHandler(ITaskHandler handler)
        {
            AddHandlers(new[] { handler });
        }

        public virtual void AddHandlers(ITaskHandler[] handlers)
        {
            _handlers.AddRange(handlers);
        }

        protected async Task InvokeNext(IMessage message)
        {
            if (!_handlers.Any()) return;
            var handlerTasks = _handlers.Select(x => Task.Run(async () => await x.HandleAsync(message))).ToArray();
            var task = Task.WhenAll(handlerTasks);
            try
            {
                await task;
            }
            catch
            {
                task.Exception?.Flatten().InnerExceptions?.Select(x => x)
                .ToList().ForEach(x =>
                    LogError(x.Message));
            }
        }

        protected void LogError(string errMessage)
        {
            Console.WriteLine($"Error Invoking Next Handler {errMessage}");
            // Logging
        }
    }
}
