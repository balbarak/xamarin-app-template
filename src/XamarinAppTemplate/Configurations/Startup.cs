using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.ViewModels;

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
            serviceCollections.AddSingleton<NavigationService>();
            serviceCollections.AddSingleton<LanguageManager>();

            serviceCollections.AddTransient<HomeViewModel>();

            serviceCollections.AddTransient<LoginViewModel>();

            serviceCollections.AddTransient<RegisterViewModel>();

            serviceCollections.AddTransient<AboutViewModel>();

            serviceCollections.AddTransient<TypographyViewModel>();

            serviceCollections.AddTransient<ThemeViewModel>();

            serviceCollections.AddSingleton<SettingsViewModel>();

            serviceCollections.AddSingleton<AppShellViewModel>();

            return serviceCollections;
        }
    }
}
