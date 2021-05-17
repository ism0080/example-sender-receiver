using Microsoft.Extensions.DependencyInjection;

namespace Example.SenderReceiver.TaskHandlers.Standard
{
    public static class StandardTaskHandlerServiceCollectionExtension
    {
        public static IServiceCollection AddStandardTaskHandlers(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
