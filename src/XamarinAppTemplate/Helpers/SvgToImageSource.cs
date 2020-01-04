using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Svg;

namespace XamarinAppTemplate
{
    public class SvgToImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource result = null;

            if (value != null && value is string src)
            {
                result = SvgImageSource.FromSvgResource($"XamarinAppTemplate.Images.Icons.{src}",30,30);
                
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
