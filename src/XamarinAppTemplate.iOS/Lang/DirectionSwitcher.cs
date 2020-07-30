using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate.iOS.Renders;
using System.Diagnostics;
using CoreGraphics;

namespace XamarinAppTemplate.iOS.Lang
{
    public class DirectionSwitcher : IDirectionSwitcher
    {
        private const string APPLE_LANGUAGES = "AppleLanguage";

        public void SwitchDirection(LanguageDirection dir)
        {

            ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");

            var windows = UIApplication.SharedApplication.Windows;
            var keyWindow = UIApplication.SharedApplication.KeyWindow;
            var shell = UIApplication.SharedApplication.KeyWindow.RootViewController.ChildViewControllerForHomeIndicatorAutoHidden as AppShellRenderer;
            var flyout = shell.ViewController as ShellFlyoutRenderer;


            UISemanticContentAttribute iosDir;

            if (dir == LanguageDirection.Ltr)
                iosDir = UISemanticContentAttribute.ForceLeftToRight;
            else
                iosDir = UISemanticContentAttribute.ForceRightToLeft;


            AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, iosDir);

            //UpdateViewsDirection(flyout.View, iosDir);

            //UpdateViewsDirection(keyWindow.RootViewController.View, iosDir);

        }

        private void UpdateViewsDirection(UIView view, UISemanticContentAttribute dir)
        {

            view.SemanticContentAttribute = dir;
            view.SetNeedsDisplay();

            if (view.Subviews.Count() == 0)
                return;

            foreach (var item in view.Subviews)
            {
                UpdateViewsDirection(item, dir);
            }

        }
    }
}