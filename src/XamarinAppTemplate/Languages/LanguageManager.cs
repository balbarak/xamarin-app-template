using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate
{
    public class LanguageManager 
    {
        public void SwitchDirection(LanguageDirection dir)
        {
            var manager = AppServiceLocator.Current.GetService<ILanguageManager>();

            manager.SwitchDirection(dir);
        }
    }
}
