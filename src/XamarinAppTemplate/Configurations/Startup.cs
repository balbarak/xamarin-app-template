using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate
{
    public class Startup
    {
        private static readonly ServiceCollection _serviceCollection = new ServiceCollection();

        public static IServiceCollection Services => _serviceCollection;

        public static void Configure()
        {
            ConfigureServices(_serviceCollection);

            AppServiceLocator.Configure(_serviceCollection);
        }

        private static IServiceCollection ConfigureServices(IServiceCollection serviceCollections)
        {

            return serviceCollections;
        }
    }
}
