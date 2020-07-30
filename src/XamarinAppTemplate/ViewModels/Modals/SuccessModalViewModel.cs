using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamarinAppTemplate.ViewModels
{
    public class SuccessModalViewModel : BaseViewModel
    {

        public override Task InitializeAsync(object navigationData)
        {
            Title = (navigationData as string) ?? Resx.AppResource.OperationSuccess;

            return Task.CompletedTask;
        }
    }
}
