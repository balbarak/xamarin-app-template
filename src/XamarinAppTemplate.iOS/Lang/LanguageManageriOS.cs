using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate.iOS.Renders;

namespace XamarinAppTemplate.iOS.Lang
{
    public class LanguageManageriOS : ILanguageManager
    {
        private const string APPLE_LANGUAGES = "AppleLanguage";

        public void SwitchDirection(LanguageDirection dir)
        {

            ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");

            

            var windows = UIApplication.SharedApplication.Windows;

            UISemanticContentAttribute iosDir;

            if (dir == LanguageDirection.Ltr)
                iosDir = UISemanticContentAttribute.ForceLeftToRight;
            else
                iosDir = UISemanticContentAttribute.ForceRightToLeft;

            AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, iosDir);

            foreach (var window in windows)
            {

                foreach (var view in window.Subviews)
                {
                    UpdateViewsDirection(view, iosDir);
                }

            }

        }

        private void UpdateViewsDirection(UIView view,UISemanticContentAttribute dir)
        {
            view.SemanticContentAttribute = dir;
            view.SetNeedsLayout();
            //view.SetNeedsDisplay();
            //view.UpdateConstraints();
            view.SetNeedsUpdateConstraints();
            if (view.Subviews.Count() > 0)
            {
                foreach (var item in view.Subviews)
                {
                    UpdateViewsDirection(item,dir);
                }
            }
            else
            {
                return;
            }

        }
    }
}