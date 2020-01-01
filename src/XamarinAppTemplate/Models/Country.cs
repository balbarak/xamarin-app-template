using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.Models
{
    public class Country
    {
        public string Id { get; set; }

        public string CodeTwo { get; set; }

        public LocaleStringSqlite Name { get; set; }
        public string PhoneCode { get; set; }

        public bool IsActive { get; set; }

        public LocaleStringSqlite Capital { get; set; }

        public int? Population { get; set; }

        public float? Latitude { get; set; }

        public float? Longtitude { get; set; }

        public double? Area { get; set; }
    }
}
