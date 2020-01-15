using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinAppTemplate.ViewModels
{
    public class ModalViewModel : BaseViewModel
    {
        public ICommand CloseCommand => new Command(async () => await _navService.CloseModal());
    }
}
