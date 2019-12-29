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
        private const string APPLE_LANGUAGES = "AppleLanguages";

        public void SwitchDirection(LanguageDirection dir)
        {
            var window = UIApplication.SharedApplication.KeyWindow;

            UISemanticContentAttribute iosDir;

            if (dir == LanguageDirection.Ltr)
                iosDir = UISemanticContentAttribute.ForceLeftToRight;
            else
                iosDir = UISemanticContentAttribute.ForceRightToLeft;

            foreach (var view in window.Subviews)
            {
                UpdateViewsDirection(view,iosDir);
            }

        }

        private void UpdateViewsDirection(UIView view,UISemanticContentAttribute dir)
        {
            view.SemanticContentAttribute = dir;
            view.SetNeedsLayout();
            view.SetNeedsDisplay();

            if (view.Subviews.Count() > 0)
            {
                foreach (var item in view.Subviews)
                {
                    UpdateViewsDirection(item,dir);
                }
            }

        }
    }
}