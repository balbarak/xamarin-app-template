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
    public class LanguageManageriOS : ILanguageManager
    {
        private const string APPLE_LANGUAGES = "AppleLanguage";

        public void SwitchDirection(LanguageDirection dir)
        {

            ObjCRuntime.Selector selector = new ObjCRuntime.Selector("setSemanticContentAttribute:");

            var windows = UIApplication.SharedApplication.Windows;
            var keyWindow = UIApplication.SharedApplication.KeyWindow;
            var shell = UIApplication.SharedApplication.KeyWindow.RootViewController.ChildViewControllerForHomeIndicatorAutoHidden as AppShellRenderer;
            var flyout = shell.ViewController as ShellFlyoutRenderer;

            var vc = keyWindow.RootViewController;

            while (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
            }

            vc.View.BackgroundColor = UIColor.Red;

            UISemanticContentAttribute iosDir;

            if (dir == LanguageDirection.Ltr)
                iosDir = UISemanticContentAttribute.ForceLeftToRight;
            else
                iosDir = UISemanticContentAttribute.ForceRightToLeft;

            AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, iosDir);


            UpdateViewsDirection(shell.ContentView,iosDir);

            foreach (var window in windows)
            {
                UIViewController root = window.RootViewController;

                if (root != null && root.View != null)
                { 
                    UpdateViewsDirection(root.View, iosDir);

                    var superView = root.View.Superview;

                    if (superView != null)
                        UpdateViewsDirection(superView,iosDir);
                }
            }

        }

        private void UpdateViewsDirection(UIView view,UISemanticContentAttribute dir)
        {
            
            view.SemanticContentAttribute = dir;
            view.SetNeedsLayout();

            if (view.Subviews.Count() > 0)
            {
                foreach (var item in view.Subviews)
                {
                    UpdateViewsDirection(item,dir);

                    Debug.WriteLine("Update view: " + item.AccessibilityIdentifier);
                }
            }
            else
            {
                return;
            }

        }
    }
}