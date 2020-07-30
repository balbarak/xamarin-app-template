using Android.Views;
using Plugin.CurrentActivity;

namespace XamarinAppTemplate.Droid.Lang
{
    public class DirectionSwitcher : IDirectionSwitcher
    {
        public void SwitchDirection(LanguageDirection dir)
        {

            var window = CrossCurrentActivity.Current.Activity.Window;
            var activity = CrossCurrentActivity.Current.Activity;

            if (dir == LanguageDirection.Ltr)
                window.DecorView.LayoutDirection = LayoutDirection.Ltr;

            if (dir == LanguageDirection.Rtl)
                window.DecorView.LayoutDirection = LayoutDirection.Rtl;

        }
    }
}