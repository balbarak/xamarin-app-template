using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseContentPage : ContentPage
    {
        private NavigationService _navService;
        private BaseViewModel _viewModel;

        public BaseContentPage()
        {
            InitializeComponent();

            _navService = AppServiceLocator.Current.GetService<NavigationService>();

            _viewModel = GetViewModel();
            BindingContext = _viewModel;
        }

        public Task InitializeViewModel(object data)
        {
            return Task.Run(()=>_viewModel.InitializeAsync(data));
        }

        protected override void OnAppearing()
        {

            if (FlowDirection != LanguageManager.CurrentFlowDirection)
                FlowDirection = LanguageManager.CurrentFlowDirection;

            base.OnAppearing();
        }

        private BaseViewModel GetViewModel()
        {
            var type = GetType();
            var viewModelType = _navService.GetPageViewModelType(type);
            var viewModel = (BaseViewModel) AppServiceLocator.Current.GetService(viewModelType);

            return viewModel;
        }
    }
}