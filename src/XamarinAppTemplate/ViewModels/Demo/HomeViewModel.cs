using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinAppTemplate.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand LoginCommand => new Command(async () => await _navService.GoToAsync<LoginViewModel>());

        public HomeViewModel()
        {

        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
