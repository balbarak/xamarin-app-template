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
        public static Task InitialDatabaseTask { get; private set; }


        public App()
        {
            InitializeComponent();

            Startup.Configure();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            InitialDatabaseTask = XamarinAppTemplateDbContext.InitDatabase();
        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }


    }
}
