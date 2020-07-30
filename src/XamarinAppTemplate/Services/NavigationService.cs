using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppTemplate.Helpers;
using XamarinAppTemplate.ViewModels;
using XamarinAppTemplate.Views;

namespace XamarinAppTemplate.Services
{
    public class NavigationService
    {
        public Task GoToAsync<TViewModelType>(object data = null) where TViewModelType : BaseViewModel
        {
            if (data != null)
                CachHelper.PassedData = data;

            var type = typeof(TViewModelType);

            return Shell.Current.GoToAsync(type.Name, true);
        }

        public async Task ShowModal<TModel>(object data = null) where TModel : BaseViewModel
        {

            var pageType = XamarinAppTemplateRoute.GetPageByViewModel(typeof(TModel));

            var page = Activator.CreateInstance(pageType) as PopupPage;

            var viewModel = AppServiceLocator.Current.GetService<TModel>();

            page.BindingContext = viewModel;

            await PopupNavigation.Instance.PushAsync(page, true);

            await Task.Run(() => viewModel.InitializeAsync(data));
        }

        public Task CloseModal()
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                return PopupNavigation.Instance.PopAsync();
            }

            return Task.CompletedTask;
        }

        public Task GoToHome()
        {
            return Shell.Current.Navigation.PopToRootAsync();
        }

        public Task GoBack()
        {
            return Shell.Current.Navigation.PopAsync();
        }

        public static void RegisterRoutes()
        {
            XamarinAppTemplateRoute.Register(typeof(HomeViewModel), typeof(HomePage));
            
            XamarinAppTemplateRoute.Register(typeof(LoginViewModel), typeof(LoginPage));
            
            XamarinAppTemplateRoute.Register(typeof(RegisterViewModel), typeof(RegisterPage));
            
            XamarinAppTemplateRoute.Register(typeof(AboutViewModel), typeof(AboutPage));
            
            XamarinAppTemplateRoute.Register(typeof(TypographyViewModel), typeof(TypographyPage));
            
            XamarinAppTemplateRoute.Register(typeof(ThemeViewModel), typeof(ThemePage));
            
            XamarinAppTemplateRoute.Register(typeof(CountryViewModel), typeof(CountryPage));
            
            XamarinAppTemplateRoute.Register(typeof(CountryDetailsViewModel), typeof(CountryDetailsPage));
            
            XamarinAppTemplateRoute.Register(typeof(ControlViewModel), typeof(ControlPage));

            XamarinAppTemplateRoute.Register(typeof(ModalViewModel), typeof(ModalPage));

            XamarinAppTemplateRoute.Register(typeof(HeaderViewModel), typeof(HeaderView));

            XamarinAppTemplateRoute.Register(typeof(ButtonViewModel), typeof(ButtonPage));

            XamarinAppTemplateRoute.Register(typeof(SuccessModalViewModel), typeof(SuccessModal));

            XamarinAppTemplateRoute.Register(typeof(ErrorModalViewModel), typeof(ErrorModal));

            XamarinAppTemplateRoute.Register(typeof(FormViewModel), typeof(FormPage));

        }
    }
}
