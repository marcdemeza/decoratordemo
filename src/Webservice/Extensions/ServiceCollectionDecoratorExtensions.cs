using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Webservice.Extensions
{
    public static class ServiceCollectionDecoratorExtensions
    {
        public static IServiceCollection AddScopedDecorator<TInterface, TImplementation>(this IServiceCollection serviceCollection, Action<DecoratorOptions<TInterface>> options)
            where TImplementation : class, TInterface
            where TInterface : class
        {
            var decoratorOptions = new DecoratorOptions<TInterface>();
            options(decoratorOptions);

            if (!decoratorOptions.Order.Any())
            {
                serviceCollection.AddScoped<TInterface, TImplementation>();
            }
            else
            {
                serviceCollection.AddScoped<TImplementation>();
                var previous = typeof(TImplementation);
                while (decoratorOptions.Order.TryDequeue(out Type result))
                {
                    if (decoratorOptions.Order.Any())
                    {
                        serviceCollection.AddScoped(result, GetImplementationFactory<object>(result, previous));
                    }
                    else
                    {
                        serviceCollection.AddScoped(GetImplementationFactory<TInterface>(result, previous));
                    }
                    previous = result;
                }
            }

            return serviceCollection;
        }

        private static Func<IServiceProvider, TInterface> GetImplementationFactory<TInterface>(Type current, Type previous)
            => provider => (TInterface)ActivatorUtilities.CreateInstance(
                provider,
                current,
                provider.GetService(previous));
    }
}
