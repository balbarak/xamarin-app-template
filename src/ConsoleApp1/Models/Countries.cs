using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public partial class Countries
    {
        public string Id { get; set; }
        public string CodeTwo { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string PhoneCode { get; set; }
        public bool IsActive { get; set; }
        public string CapitalEnglish { get; set; }
        public string CapitalArabic { get; set; }
        public int? Population { get; set; }
        public float? Latitude { get; set; }
        public float? Longtitude { get; set; }
        public double? Area { get; set; }
    }
}
