using System.Threading.Tasks;

namespace Example.SenderReceiver.TaskHandlers.Common.Interfaces
{
    public interface IPipeline
    {
        string Name { get; }
        Task StartAsync();
    }
}
