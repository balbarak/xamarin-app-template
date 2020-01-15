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
        private readonly Task _initTask;

        public BaseContentPage()
        {
            InitializeComponent();

            _viewModel = GetViewModel();
            BindingContext = _viewModel;

            _initTask = Task.Run(() => _viewModel.InitializeAsync(CachHelper.PassedData));
        }

        protected override async void OnAppearing()
        {
            if (FlowDirection != LanguageManager.CurrentFlowDirection)
                FlowDirection = LanguageManager.CurrentFlowDirection;

            await Task.WhenAny(_initTask);

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