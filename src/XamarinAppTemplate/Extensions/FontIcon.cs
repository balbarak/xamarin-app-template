using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class FontIcon : FontImageSource
    {
        public FontIcon()
        {
            Application.Current.Resources.TryGetValue("FA-Solid", out object value);

            if (value != null && value is OnPlatform<string> font)
            {
                string fontName = null;

                foreach (var item in font.Platforms)
                {
                    if (item.Platform[0] == Device.RuntimePlatform)
                    {
                        fontName = item.Value as string;
                        break;
                    }
                }
                
                this.FontFamily = fontName;
            }
        }
    }
}
