using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

using Foundation;
using UIKit;

namespace XamarinAppTemplate.iOS.Lang
{
    public class LanguageManageriOS : ILanguageManager
    {
        [DllImport(ObjCRuntime.Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);


        public void SwitchDirection(LanguageDirection dir)
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;

            //var ee = NSUserDefaults.StandardUserDefaults.StringForKey("PGCurrentLanguageKey");
            //var ee = NSUserDefaults.StandardUserDefaults.StringForKey("AppleLanguages");

            //NSUserDefaults.StandardUserDefaults.SetString("ar", "AppleLanguages");

            //NSUserDefaults.StandardUserDefaults.Synchronize();

            //var windows = UIApplication.SharedApplication.Windows;

            foreach (var window in UIApplication.SharedApplication.Windows)
            {
                foreach (var viewe in window.Subviews)
                {
                    viewe.RemoveFromSuperview();

                    window.AddSubview(viewe);
                }
            }
            //Localize
            //NSUserDefaults.StandardUserDefaults.
            //Selector selector = new Selector("setSemanticContentAttribute:");
            //IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, UISemanticContentAttribute.ForceRightToLeft);

            //UIView.Appearance.sem
        }
    }
}