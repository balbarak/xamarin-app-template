using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly ILanguageManager _languageManager;

        private bool _isDarkTheme;

        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set => SetProperty(ref _isDarkTheme, value, nameof(IsDarkTheme), OnThemeChanged);
        }

        public SettingsViewModel(ILanguageManager manager)
        {
            _languageManager = manager;
        }

        private void OnThemeChanged()
        {
            if (IsDarkTheme)
                _languageManager.SwitchDirection(LanguageDirection.Ltr);
            else
                _languageManager.SwitchDirection(LanguageDirection.Rtl);
        }
    }
}
