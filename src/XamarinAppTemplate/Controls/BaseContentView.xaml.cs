using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Helpers;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseContentView : ContentView
    {
        private BaseViewModel _viewModel;

        public BaseContentView()
        {
            InitializeComponent();
            _viewModel = GetViewModel();

            BindingContext = _viewModel;
        }

        private BaseViewModel GetViewModel()
        {
            var viewModelType = XamarinAppTemplateRoute.GetViewModelByPage(this.GetType());

            var result = AppServiceLocator.Current.GetService(viewModelType) as BaseViewModel;

            return result;
        }

        //TODO: maybe there is another better event to set the ViewModel for content view
        protected override async void OnParentSet()
        {
            if (!_viewModel.IsInitialized)
            {
                _viewModel.IsInitialized = true;

                await _viewModel.InitializeAsync(null);
            }

            base.OnParentSet();
        }
    }
}