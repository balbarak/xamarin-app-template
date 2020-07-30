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
    public enum LanguageDirection
    {
        Ltr = 1,
        Rtl = 2
    }

    public class Localization
    {
        public static CultureInfo ArabicCulture => new CultureInfo("ar-EG");

        public static CultureInfo EnglishCulture => new CultureInfo("en-US");

        public static bool IsEnglish
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.Name.Contains("en");
            }
        }
        
        public static FlowDirection CurrentFlowDirection { get; set; } = Device.FlowDirection;

        public void ChangeDirection(LanguageDirection dir)
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

            var manager = AppServiceLocator.Current.GetService<IDirectionSwitcher>();

            if (dir == LanguageDirection.Ltr)
                ThemeManager.SetDefaultTheme();
            else
                ThemeManager.SetRTLTheme();

            manager.SwitchDirection(dir);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                var type = Application.Current.MainPage.GetType();
                var app = Activator.CreateInstance(type) as Page;

                if (Application.Current.MainPage is Shell shell)
                {
                    var uri = shell.CurrentState.Location;
                    Application.Current.MainPage = app;

                    Shell.Current.GoToAsync(uri, false);
                }
                else
                {
                    Application.Current.MainPage = app;
                }

            });
        }

    }
}
