using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, List<ICoreModule> modules)
        {
            modules.ForEach(m => m.Load(serviceCollection));
            return ServiceTool.Create(serviceCollection);
        }
    }
}