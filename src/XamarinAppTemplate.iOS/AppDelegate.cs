using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using FFImageLoading.Svg.Forms;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using Plugin.Toasts;
using TouchEffect.iOS;
using UIKit;
using Xamarin.Forms;
using XamarinAppTemplate.iOS.Lang;

namespace XamarinAppTemplate.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        [System.Runtime.InteropServices.DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            //swipe experimental
            Forms.SetFlags("SwipeView_Experimental");

            global::Xamarin.Forms.Forms.Init();

            SetupPlugins();

            Startup.Services.AddTransient<IDirectionSwitcher, DirectionSwitcher>();

            LoadApplication(new App());
 
            var result =  base.FinishedLaunching(app, options);

            return result;
        }

        private void SetupPlugins()
        {
            DependencyService.Register<ToastNotification>();
            
            TouchEffectPreserver.Preserve();

            ToastNotification.Init();

            Xamarin.Forms.Svg.iOS.SvgImage.Init();  //need to write here

            Rg.Plugins.Popup.Popup.Init();

            var ignore = typeof(SvgCachedImage);
            CachedImageRenderer.Init(); // Initializing FFImageLoading
        }
    }
}
