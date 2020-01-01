using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.Models
{
    [Owned]
    public class LocaleString
    {
        public string Arabic { get; set; }

        public string English { get; set; }

        public LocaleString()
        {

        }

        public LocaleString(string arabic,string english)
        {
            this.Arabic = arabic;
            this.English = english;
        }

        public override string ToString()
        {
            if (LanguageManager.IsEnglish)
                return English;
            else
                return Arabic;
        }
    }
}
