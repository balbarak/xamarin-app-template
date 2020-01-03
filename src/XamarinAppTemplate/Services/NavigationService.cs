using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppTemplate.ViewModels;
using XamarinAppTemplate.Views;

namespace XamarinAppTemplate.Services
{
    public class NavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            MapViewModels();
        }

        public Task Init()
        {
            return Task.CompletedTask;
        }

        public Task GoToAsync(string nav)
        {
            return Shell.Current.GoToAsync(nav);
        }

        public Task PushAsync<TViewModel>(object data) where TViewModel : BaseViewModel => PushAsyncInternal<TViewModel>(data);

        public Task PushAsync<TViewModel>() where TViewModel : BaseViewModel => PushAsyncInternal<TViewModel>(null);

        public Type GetPageViewModelType(Type page)
        {

            if (!_mappings.ContainsValue(page))
            {
                throw new KeyNotFoundException($"No map for ${page} was found on navigation mappings");
            }

            return _mappings.FirstOrDefault(x => x.Value == page).Key;
        }

        public Type GetViewModelPage(Type viewModel)
        {

            if (!_mappings.ContainsKey(viewModel))
            {
                throw new KeyNotFoundException($"No map for ${viewModel} was found on navigation mappings");
            }

            return _mappings[viewModel];
        }

        private async Task PushAsyncInternal<TViewModel>(object data) where TViewModel : BaseViewModel
        {
            var pageType = GetViewModelPage(typeof(TViewModel));

            var page = Activator.CreateInstance(pageType) as BaseContentPage;

            page.IsInitialized = true;

            var pushTask =  Shell.Current.Navigation.PushAsync(page);

            var initTask = page.InitializeViewModel(data);

            await Task.WhenAll(pushTask, initTask);
        }

        private void MapViewModels()
        {
            _mappings.Add(typeof(HomeViewModel),typeof(HomePage));

            _mappings.Add(typeof(LoginViewModel),typeof(LoginPage));
            
            _mappings.Add(typeof(RegisterViewModel),typeof(RegisterPage));

            _mappings.Add(typeof(AboutViewModel),typeof(AboutPage));

            _mappings.Add(typeof(TypographyViewModel),typeof(TypographyPage));

            _mappings.Add(typeof(ThemeViewModel),typeof(ThemePage));

            _mappings.Add(typeof(SettingsViewModel),typeof(SettingsPage));

            _mappings.Add(typeof(CountryViewModel), typeof(CountryPage));

            _mappings.Add(typeof(CountryDetailsViewModel), typeof(CountryDetailsPage));

            _mappings.Add(typeof(ControlViewModel), typeof(ControlPage));

        }
    }
}
