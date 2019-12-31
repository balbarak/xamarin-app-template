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


            UISemanticContentAttribute iosDir;

            if (dir == LanguageDirection.Ltr)
                iosDir = UISemanticContentAttribute.ForceLeftToRight;
            else
                iosDir = UISemanticContentAttribute.ForceRightToLeft;

            AppDelegate.IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, iosDir);

            UpdateViewsDirection(keyWindow.RootViewController.View, iosDir);

            //UpdateViewsDirection(shell.ContentView, iosDir);

            //var mainRoot = keyWindow.RootViewController;

            ///UpdateViewsDirection(mainRoot.View, iosDir);

            //foreach (var window in windows)
            //{
            //    UIViewController root = window.RootViewController;

            //    var ee = root.NavigationController;

            //    if (root != null && root.View != null)
            //    {
            //        var presentedController = root.PresentedViewController;

            //        if (presentedController != null)
            //        {

            //            var currentView = presentedController.View;

            //            if (currentView != null)
            //            {
            //                UpdateViewsDirection(currentView, iosDir);
            //            }
            //        }

            //        UpdateViewsDirection(root.View, iosDir);

            //        var superView = root.View.Superview;

            //        if (superView != null)
            //            UpdateViewsDirection(superView, iosDir);
            //    }
            //}

        }

        private void UpdateViewsDirection(UIView view, UISemanticContentAttribute dir)
        {

            view.SemanticContentAttribute = dir;
            view.SetNeedsLayout();
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