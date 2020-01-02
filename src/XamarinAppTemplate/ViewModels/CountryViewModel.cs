using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAppTemplate.Models;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.Wrappers;

namespace XamarinAppTemplate.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        private readonly CountryService _service;

        public ObservableCollection<CountryWrapper> Countries { get; private set; } = new ObservableCollection<CountryWrapper>();

        public ICommand DetailsCommand => new Command(async (arg) => await Details(arg));

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

            foreach (var item in countries)
            {
                Countries.Add(new CountryWrapper(item));

                if (isIos)
                    await Task.Delay(10);
            }

            IsBusy = false;


        }

        public Task Details(object entity)
        {
            if (entity == null)
                return Task.CompletedTask;

            return _navService.PushAsync<CountryDetailsViewModel>(entity);
        }
    }
}
