using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinAppTemplate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool state { get; set; }

        public LoginViewModel()
        {

        }

        public async override Task InitializeAsync(object navigationData)
        {
            await Task.Delay(2000);

            await MainThread.InvokeOnMainThreadAsync(()=> App.Current.MainPage.DisplayAlert("Nehahaha", "done", "ok"));

        }
    }
}
