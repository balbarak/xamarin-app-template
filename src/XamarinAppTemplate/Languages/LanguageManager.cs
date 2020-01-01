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

        public static event EventHandler<LanguageDirection> OnDirectionChanged;

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

            SetStyles(dir == LanguageDirection.Rtl);

            manager.SwitchDirection(dir);

            if (Device.RuntimePlatform == Device.iOS)
                Application.Current.MainPage = new AppShell();

            OnDirectionChanged?.Invoke(this, dir);
            
        }

        private void SetStyles(bool isRtl)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (isRtl)
            {
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new FontStyle());
                mergedDictionaries.Add(new LightTheme());
                mergedDictionaries.Add(new AppStyle());
                mergedDictionaries.Add(new RTLStyle());
            }
            else
            {
                mergedDictionaries.Clear();
                mergedDictionaries.Add(new FontStyle());
                mergedDictionaries.Add(new LightTheme());
                mergedDictionaries.Add(new AppStyle());


            }
        }
    }
}
