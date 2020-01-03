using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Microsoft.Extensions.DependencyInjection;
using XamarinAppTemplate.Droid.Lang;
using Plugin.CurrentActivity;
using TouchEffect.Android;

namespace XamarinAppTemplate.Droid
{
    [Activity(Label = "XamarinAppTemplate", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Startup.Services.AddTransient<ILanguageManager, LanguageManagerAndroid>();

            base.OnCreate(savedInstanceState);

            
            RegisterPlugins(savedInstanceState);

            //swipe experimental
            Forms.SetFlags("SwipeView_Experimental");

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
            //initialize matrial design
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);

            

            LoadApplication(new App());

        }

        private void RegisterPlugins(Bundle bundle)
        {
            DependencyService.Register<ToastNotification>();

            TouchEffectPreserver.Preserve();

            ToastNotification.Init(this);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: false);

            CrossCurrentActivity.Current.Init(this, bundle);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}