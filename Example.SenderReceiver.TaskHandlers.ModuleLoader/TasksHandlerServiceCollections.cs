using Example.SenderReceiver.App.ServiceCollectionExtension;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using Example.SenderReceiver.TaskHandlers.Standard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Example.SenderReceiver.TaskHandlers.ModuleLoader
{
    public static class TasksHandlerServiceCollections
    {
        public static IServiceCollection AddTaskHandlers(this IServiceCollection serviceCollection)
        {
            GetTaskHandlers<ITaskHandler>(typeof(TasksHandlerServiceCollections))
                .ToList()
                .ForEach(t => { serviceCollection.AddSingleton(typeof(ITaskHandler), t); });

            return serviceCollection.AddStandardTaskHandlers().AddCustomTaskHandlers();
        }

        public static ICollection<Type> GetImplementationTypes<T>(IEnumerable<Type> types)
        {
            return types
                .Where(x => typeof(ITaskHandler).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList();
        }

        public static ICollection<Type> GetTaskHandlers<T>(Type type)
        {
            return GetImplementationTypes<ITaskHandler>(type.Assembly.GetReferencedAssemblies()
                .SelectMany(x => Assembly.Load(x).GetTypes()));
        }
    }
}
