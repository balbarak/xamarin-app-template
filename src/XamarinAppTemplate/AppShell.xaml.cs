using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinAppTemplate.Helpers;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        
        public AppShell()
        {
            InitializeComponent();

            BindingContext = AppServiceLocator.Current.GetService<AppShellViewModel>();
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }
    }
}
