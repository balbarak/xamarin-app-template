using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinAppTemplate.Wrappers;

namespace XamarinAppTemplate.ViewModels
{
    public class CountryDetailsViewModel : BaseViewModel
    {
        private CountryWrapper _country;

        public CountryWrapper Country { get => _country; set => SetProperty(ref _country, value); }


        public override async Task InitializeAsync(object navigationData)
        {
            var country = navigationData as CountryWrapper;

            Country = country;

            Title = Country.Name.ToString();
        }
    }
}
