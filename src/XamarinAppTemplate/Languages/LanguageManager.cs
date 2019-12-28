﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class LanguageManager 
    {
        public static CultureInfo ArabicCulture => new CultureInfo("ar-SA");
        public static CultureInfo EnglishCulture => new CultureInfo("en-US");

        public static FlowDirection CurrentFlowDirection { get; set; }

        public void SwitchDirection(LanguageDirection dir)
        {
            Shell.Current.Navigation.PopAsync();

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

            manager.SwitchDirection(dir);
        }
    }
}