using Microsoft.Extensions.DependencyInjection;

namespace Example.SenderReceiver.App.ServiceCollectionExtension
{
    public static class CustomTaskHandlers
    {
        public static IServiceCollection AddCustomTaskHandlers(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
