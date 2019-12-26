using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppTemplate.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool state { get; set; }

        public LoginViewModel()
        {

        }

        public override Task InitializeAsync(object navigationData)
        {

            return base.InitializeAsync(navigationData);
        }
    }
}
