using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate;
using XamarinAppTemplate.iOS.Renders;
using XamarinAppTemplate.iOS.Transitions;

[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]

namespace XamarinAppTemplate.iOS.Renders
{
    public class AppShellRenderer : ShellRenderer
    {
        public AppShellRenderer()
        {

        }

        protected override IShellFlyoutRenderer CreateFlyoutRenderer()
        {
            return new ShellFlyoutRenderer()
            {
                FlyoutTransition = new SlideFlyoutTransitionRtl()
            };
        }

    }


}