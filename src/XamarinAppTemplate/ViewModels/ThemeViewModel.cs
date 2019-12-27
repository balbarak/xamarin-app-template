using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinAppTemplate.ViewModels
{
    public class ThemeViewModel : BaseViewModel
    {
        public ICommand StartLoadingCommand => new Command(StartLoading);

        public ICommand ShowToasterCommand => new Command(ShowToaster);

        public string Icon => "\uf2ca";
        public ThemeViewModel()
        {
            Title = "Themes";
        }


        private async void StartLoading()
        {

            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }
        private async void ShowToaster(object obj)
        {
            var notification = DependencyService.Get<IToastNotificator>();

            var option = new NotificationOptions()
            {
                Title = "Hello this is a notification",
                Description = "You are doing it right away",
                AllowTapInNotificationCenter = true,
            };

            option.AndroidOptions.HexColor = "#FF0000";

            var result = await notification.Notify(option);
        }
    }
}
