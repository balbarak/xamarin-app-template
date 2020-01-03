using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Svg;
using Xamarin.Forms.Xaml;

namespace XamarinAppTemplate
{
    [ContentProperty(nameof(Source))]
    public class SvgImageResourceExtension : BindableObject, IMarkupExtension<ImageSource>
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            nameof(Color),
            typeof(Color),
            typeof(SvgImageResourceExtension),
            Color.Default);
        public string Source { get; set; }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public ImageSource ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            var result = SvgImageSource.FromSvgResource($"XamarinAppTemplate.Images.Icons.{Source}", color: Color);

            return result;

        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<ImageSource>).ProvideValue(serviceProvider);
        }
    }
}
