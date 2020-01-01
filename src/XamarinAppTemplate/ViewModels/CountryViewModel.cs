using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamarinAppTemplate.Models;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.Wrappers;

namespace XamarinAppTemplate.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        private readonly CountryService _service;


        public ObservableCollection<CountryWrapper> Countries { get; private set; } = new ObservableCollection<CountryWrapper>();

        public CountryViewModel(CountryService service)
        {
            _service = service;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            Title = Resx.AppResource.Countries;


            IsBusy = true;

            var countries = await _service.GetAll();

            foreach (var item in countries)
            {
                Countries.Add(new CountryWrapper(item));
            }

            IsBusy = false;
            

        }
    }
}
