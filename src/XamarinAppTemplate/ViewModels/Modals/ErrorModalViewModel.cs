using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppTemplate.ViewModels
{
    public class ErrorModalViewModel : BaseViewModel
    {
        private string _message;

        public string Message { get => _message; set => SetProperty(ref _message, value); }


        public override Task InitializeAsync(object navigationData)
        {
            Message = navigationData as string;

            return base.InitializeAsync(navigationData);
        }
    }
}
