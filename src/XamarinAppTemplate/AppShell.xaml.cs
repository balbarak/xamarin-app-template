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

            RegisterRoutes();

            var viewModel = AppServiceLocator.Current.GetService<AppShellViewModel>();

            BindingContext = viewModel;
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }

        private void RegisterRoutes()
        {
            
            //Routing.RegisterRoute("test", new TestRoute());

        }

        public void TestUpdate()
        {
            this.OnPropertyChanged();

        }

    }
}
