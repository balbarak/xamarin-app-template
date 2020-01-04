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
    public class SvgImageResourceExtension : BindableObject, IMarkupExtension
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
            nameof(Color),
            typeof(Color),
            typeof(SvgImageResourceExtension),
            default(Color),
            propertyChanged:OnColorChanged);
        public string Source { get; set; }

        public bool IsColorChanged { get; set; }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            var result = SvgImageSource.FromSvgResource($"XamarinAppTemplate.Images.Icons.{Source}", color: Color);

            return result;

        }

        static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var sender = bindable as SvgImageResourceExtension;
            sender.IsColorChanged = true;
        }

    }
}
