using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Example.SenderReceiver.TaskHandlers.Common.Interfaces
{
    public interface ITaskHandler
    {
        string Name { get; }
        void Initialize(IBindingInfo configuration);
        Task StartAsync();
        void AddHandlers(ITaskHandler[] handlers);
        void AddHandler(ITaskHandler handler);
        Task HandleAsync(IMessage message);
    }
}
