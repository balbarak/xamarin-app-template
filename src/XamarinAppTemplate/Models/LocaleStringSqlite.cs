using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.Models
{
    [Owned]
    public class LocaleStringSqlite
    {
        public string Arabic { get; set; }

        public string English { get; set; }

        public LocaleStringSqlite()
        {

        }

        public LocaleStringSqlite(string arabic,string english)
        {
            this.Arabic = arabic;
            this.English = english;
        }

        public override string ToString()
        {
            if (Localization.IsEnglish)
                return English;
            else
                return Arabic;
        }
    }
}
