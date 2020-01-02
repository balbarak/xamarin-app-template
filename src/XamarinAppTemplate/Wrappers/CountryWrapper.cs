using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinAppTemplate.Models;

namespace XamarinAppTemplate.Wrappers
{
    public class CountryWrapper : WrapperBase<Country>
    {
        public LocaleStringSqlite Name { get => GetValue<LocaleStringSqlite>(); set => SetValue(value);}

        public ImageSource Image => ImageSource.FromResource($"XamarinAppTemplate.Images.flags.{Model.Id}.png");

        public LocaleStringSqlite Capital => Model.Capital;

        public int? Population => Model.Population;

        public CountryWrapper(Country model) : base(model)
        {

        }
    }
}
