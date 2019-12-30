using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate;
using XamarinAppTemplate.iOS.Renders;

[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]

namespace XamarinAppTemplate.iOS.Renders
{
    public class AppShellRenderer : ShellRenderer
    {
        public AppShellRenderer()
        {

        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var result = base.CreateShellFlyoutContentRenderer();
            var view = result.ViewController.View;

            view.SemanticContentAttribute = UISemanticContentAttribute.ForceRightToLeft;
            view.SetNeedsLayout();

            return result;
        }

        protected override IShellItemTransition CreateShellItemTransition()
        {
            var result = base.CreateShellItemTransition();

            return result;
        }
    }


}