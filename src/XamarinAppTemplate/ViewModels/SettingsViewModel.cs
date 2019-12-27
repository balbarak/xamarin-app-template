using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
		private bool _isDarkTheme;

		public bool IsDarkTheme
		{
			get => _isDarkTheme;
			set => SetProperty(ref _isDarkTheme,value,nameof(IsDarkTheme),OnThemeChanged);
		}


		private void OnThemeChanged()
		{

		}
	}
}
