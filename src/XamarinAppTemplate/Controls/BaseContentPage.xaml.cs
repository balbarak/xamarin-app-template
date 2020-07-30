using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Helpers;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseContentPage : ContentPage
    {
        private BaseViewModel _viewModel;

        public BaseContentPage()
        {
            InitializeComponent();

            _viewModel = GetViewModel();
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            if (FlowDirection != Localization.CurrentFlowDirection)
                FlowDirection = Localization.CurrentFlowDirection;

            if (!_viewModel.IsInitialized)
            {
                _viewModel.IsInitialized = true;

                await _viewModel.InitializeAsync(CachHelper.PassedData);
            }
            
            await _viewModel.OnAppearing();

            base.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            await _viewModel.OnDisappearing();

            base.OnDisappearing();
        }

        private BaseViewModel GetViewModel()
        {
            var viewModelType = XamarinAppTemplateRoute.GetViewModelByPage(this.GetType());

            var result = AppServiceLocator.Current.GetService(viewModelType) as BaseViewModel;

            return result;
        }
    }
}