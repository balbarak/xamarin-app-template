using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinAppTemplate.Models;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.Wrappers;

namespace XamarinAppTemplate.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        private CountryWrapper _selectedCountry;
        private readonly CountryService _service;
        private ObservableCollection<CountryWrapper> _countries;

        public ObservableCollection<CountryWrapper> Countries { get => _countries; set => SetProperty(ref _countries, value); }
        
        public ICommand DetailsCommand => new Command(async (arg) => await Details(arg));

        public CountryWrapper SelectedCountry { get => _selectedCountry; set => SetProperty(ref _selectedCountry, value); }

        public bool Ok { get; set; } = true;

        public CountryViewModel(CountryService service)
        {
            _service = service;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Title = Resx.AppResource.Countries;

            await LoadCountries();

        }


        public async Task LoadCountries()
        {
            IsBusy = true;

            bool isIos = Device.RuntimePlatform == Device.iOS;

            await Task.WhenAny(App.InitialDatabaseTask);

            var countries = await _service.GetAll();

            var collections = new ObservableCollection<CountryWrapper>();

            foreach (var item in countries)
            {
                collections.Add(new CountryWrapper(item));
            }

            Countries = collections;

            IsBusy = false;
        }

        public Task Details(object entity)
        {
            if (entity == null)
                return Task.CompletedTask;

            SelectedCountry = null;

            return _navService.GoToAsync<CountryDetailsViewModel>(entity);
        }
    }
}
