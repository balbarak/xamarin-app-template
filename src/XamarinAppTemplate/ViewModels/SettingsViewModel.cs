using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAppTemplate.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly ILanguageManager _languageManager;

        private bool _isDarkTheme;
        private bool _isArabic;

        public bool IsArabic
        {
            get => _isArabic;
            set => SetProperty(ref _isArabic, value, nameof(IsArabic), OnLanguageChanged);
        }

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set => SetProperty(ref _isDarkTheme, value, nameof(IsDarkTheme), OnThemeChanged);
        }

        public SettingsViewModel(ILanguageManager manager)
        {
            _languageManager = manager;
        }

        public override Task InitializeAsync(object navigationData)
        {
            Title = Resx.AppResource.Settings;

            return base.InitializeAsync(navigationData);
        }

        private void OnThemeChanged()
        {

        }

        private void OnLanguageChanged()
        {
            if (IsArabic)
                SwitchDirection(LanguageDirection.Rtl);
            else
                SwitchDirection(LanguageDirection.Ltr);
        }
    }
}
