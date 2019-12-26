using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    public class BaseContentPage : ContentPage
    {
        private NavigationService _navService;
        private BaseViewModel _viewModel;

        public bool IsInitialized { get; set; }

        public BaseContentPage()
        {
            _navService = AppServiceLocator.Current.GetService<NavigationService>();
            _viewModel = GetViewModel();
            BindingContext = _viewModel;

            SetDynamicResource(BackgroundColorProperty, "PageBackgroundColor");
        }

        public Task InitializeViewModel(object data)
        {
            IsInitialized = true;

            return _viewModel.InitializeAsync(data);
        }

        protected async override void OnAppearing()
        {
            if (!IsInitialized)
            {
                await _viewModel.InitializeAsync(null);

                IsInitialized = true;
            }

            base.OnAppearing();
        }

        private BaseViewModel GetViewModel()
        {
            var type = GetType();
            var viewModelType = _navService.GetPageViewModelType(type);
            var viewModel = AppServiceLocator.Current.GetService(viewModelType) as BaseViewModel;

            return viewModel;
        }
    }
}