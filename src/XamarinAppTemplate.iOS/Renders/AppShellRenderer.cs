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
        public UIView ContentView { get; private set; }

        public AppShellRenderer()
        {

        }

        public void ReCreateFlyout()
        {
               
        }

        protected override IShellFlyoutRenderer CreateFlyoutRenderer()
        {
            var result = new ShellFlyoutRenderer()
            {

                FlyoutTransition = new SlideFlyoutTransitionRtl(),
            };

            
            return result;
        }

        protected override IShellFlyoutContentRenderer CreateShellFlyoutContentRenderer()
        {
            var result =  base.CreateShellFlyoutContentRenderer();

            ContentView = result.ViewController.View;
            
            return result;
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        {
            var result =  base.CreateShellItemRenderer(item);


            return result;
        }
    }


}