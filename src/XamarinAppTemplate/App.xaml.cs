using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Services;
using XamarinAppTemplate.Views;

namespace XamarinAppTemplate
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.Configure();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            
        }


        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        private Task InitializeNavigation()
        {
            var nav = AppServiceLocator.Current.GetService<NavigationService>();

            return nav.Init();
        }

    }
}
