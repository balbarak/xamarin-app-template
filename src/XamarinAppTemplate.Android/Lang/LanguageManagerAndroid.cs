using Android.Views;
using Plugin.CurrentActivity;

namespace XamarinAppTemplate.Droid.Lang
{
    public class LanguageManagerAndroid : ILanguageManager
    {
        public void SwitchDirection(LanguageDirection dir)
        {

            var window = CrossCurrentActivity.Current.Activity.Window;

            if (dir == LanguageDirection.Ltr)
                window.DecorView.LayoutDirection = LayoutDirection.Ltr;

            if (dir == LanguageDirection.Rtl)
                window.DecorView.LayoutDirection = LayoutDirection.Rtl;

        }
    }
}