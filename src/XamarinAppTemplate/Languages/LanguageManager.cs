using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class LanguageManager
    {
        public static CultureInfo ArabicCulture => new CultureInfo("ar-SA");
        public static CultureInfo EnglishCulture => new CultureInfo("en-US");

        public static FlowDirection CurrentFlowDirection { get; set; } = Device.FlowDirection;

        public void SwitchDirection(LanguageDirection dir)
        {
            if (dir == LanguageDirection.Rtl)
            {
                CurrentFlowDirection = FlowDirection.RightToLeft;
                Thread.CurrentThread.CurrentCulture = ArabicCulture;
                Thread.CurrentThread.CurrentUICulture = ArabicCulture;

            }
            else
            {
                CurrentFlowDirection = FlowDirection.LeftToRight;
                Thread.CurrentThread.CurrentCulture = EnglishCulture;
                Thread.CurrentThread.CurrentUICulture = EnglishCulture;
            }

            var manager = AppServiceLocator.Current.GetService<ILanguageManager>();

            if (dir == LanguageDirection.Ltr)
                ThemeManager.SetDefaultTheme();
            else
                ThemeManager.SetRTLTheme();

            manager.SwitchDirection(dir);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Application.Current.MainPage = new AppShell();
            });
        }

    }
}
