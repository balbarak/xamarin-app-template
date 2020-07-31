using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppTemplate.ViewModels
{
    public class ControlViewModel : BaseViewModel
    {
       
        public override Task InitializeAsync(object navigationData)
        {
            Title = Resx.AppResource.Controls;

            return base.InitializeAsync(navigationData);

            
        }
    }
}
