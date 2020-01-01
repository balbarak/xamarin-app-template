using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Persistance;
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

        protected override async void OnStart()
        {
            var context = await XamarinAppTemplateDbContext.InitDatabase();

            await context.EnsureSeeding();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }


    }
}
