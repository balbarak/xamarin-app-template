using FFImageLoading.Svg.Forms;
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
            SQLitePCL.Batteries.Init();

            ConfigureServices(_serviceCollection);

            Xamarin.Forms.Svg.SvgImageSource.RegisterAssembly();

            AppServiceLocator.Configure(_serviceCollection);

            NavigationService.RegisterRoutes();
        }

        private static IServiceCollection ConfigureServices(IServiceCollection serviceCollections)
        {
            serviceCollections.AddSingleton<NavigationService>();
            serviceCollections.AddSingleton<Localization>();
            serviceCollections.AddSingleton<CountryService>();

            serviceCollections.AddTransient<HomeViewModel>();

            serviceCollections.AddTransient<LoginViewModel>();

            serviceCollections.AddTransient<RegisterViewModel>();

            serviceCollections.AddTransient<AboutViewModel>();

            serviceCollections.AddTransient<TypographyViewModel>();

            serviceCollections.AddTransient<ThemeViewModel>();

            serviceCollections.AddTransient<CountryViewModel>();

            serviceCollections.AddTransient<CountryDetailsViewModel>();

            serviceCollections.AddTransient<ControlViewModel>();

            serviceCollections.AddTransient<AppShellViewModel>();

            serviceCollections.AddTransient<ModalViewModel>();

            serviceCollections.AddTransient<HeaderViewModel>();

            serviceCollections.AddTransient<ButtonViewModel>();

            serviceCollections.AddTransient<SuccessModalViewModel>();

            serviceCollections.AddTransient<ErrorModalViewModel>();

            serviceCollections.AddTransient<FormViewModel>();

            return serviceCollections;
        }
    }
}
