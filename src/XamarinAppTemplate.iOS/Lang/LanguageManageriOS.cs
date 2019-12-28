using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace XamarinAppTemplate.iOS.Lang
{
    public class LanguageManageriOS : ILanguageManager
    {
        private const string APPLE_LANGUAGES = "AppleLanguages";

        public void SwitchDirection(LanguageDirection dir)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var rootView = window.RootViewController;

            var shell = rootView.ChildViewControllerForHomeIndicatorAutoHidden;

            var childs = rootView.ChildViewControllers;
           
            rootView.View.SemanticContentAttribute = UISemanticContentAttribute.ForceLeftToRight;
            rootView.View.SetNeedsLayout();
            rootView.View.SetNeedsDisplay();


            var shellRender = shell.ChildViewControllers[0] as ShellItemRenderer;

            var navController = shellRender.SelectedViewController as UINavigationController;

            navController.Title = "fuck off";
        }

        private void SetUserLangugage(string lang)
        {
            NSUserDefaults.StandardUserDefaults.SetString(lang, APPLE_LANGUAGES);

        }
    }
}