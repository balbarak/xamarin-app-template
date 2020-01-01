using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class ThemeManager
    {
        public static bool IsDark { get; private set; }

        public static void SetDefaultTheme()
        {
            IsDark = false;

            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            mergedDictionaries.Clear();

            mergedDictionaries.Add(new FontStyle());
            mergedDictionaries.Add(new LightTheme());
            mergedDictionaries.Add(new AppStyle());
        }

        public static void SetRTLTheme()
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            mergedDictionaries.Clear();

            mergedDictionaries.Add(new FontStyle());
            mergedDictionaries.Add(new LightTheme());
            mergedDictionaries.Add(new AppStyle());
            mergedDictionaries.Add(new RTLStyle());
        }
    }
}
