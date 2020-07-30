using System;
using System.Diagnostics;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate.iOS.Lang;
using XamarinAppTemplate.iOS.Renders;

namespace XamarinAppTemplate.iOS.Transitions
{
    public class SlideFlyoutTransitionRtl : IShellFlyoutTransition
    {


        public void LayoutViews(CGRect bounds, nfloat openPercent, UIView flyout, UIView shell, FlyoutBehavior behavior)
        {
            if (behavior == FlyoutBehavior.Locked)
                openPercent = 1;

            nfloat flyoutWidth = (nfloat)(Math.Min(bounds.Width, bounds.Height) * 0.8);
            nfloat openLimit = flyoutWidth;
            nfloat openPixels = openLimit * openPercent;

            if (behavior == FlyoutBehavior.Locked)
                shell.Frame = new CGRect(bounds.X + flyoutWidth, bounds.Y, bounds.Width - flyoutWidth, bounds.Height);
            else
                shell.Frame = bounds;

            var shellWidth = shell.Frame.Width;

            var positionY = shellWidth - openPixels;

            var currentFlowDirection = Localization.CurrentFlowDirection;

            if (currentFlowDirection == FlowDirection.LeftToRight)
                flyout.Frame = new CGRect(-openLimit + openPixels, 0, flyoutWidth, bounds.Height);
            else
                flyout.Frame = new CGRect(positionY, 0, flyoutWidth, bounds.Height);


            if (behavior != FlyoutBehavior.Locked)
            {
                var shellOpacity = (nfloat)(0.5 + (0.5 * (1 - openPercent)));
                shell.Layer.Opacity = (float)shellOpacity;
            }

            flyout.Tag = 300;
        }
    }
}
