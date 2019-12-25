using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinAppTemplate.Helpers;

namespace XamarinAppTemplate
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("test", new TestRoute());
        }
    }
}
