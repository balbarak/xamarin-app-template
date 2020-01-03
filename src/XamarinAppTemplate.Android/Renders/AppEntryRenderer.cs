using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Widget;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAppTemplate.Droid.Renders;

[assembly: ExportRenderer(typeof(Entry), typeof(AppEntryRenderer))]

namespace XamarinAppTemplate.Droid.Renders
{
    public class AppEntryRenderer : EntryRenderer
    {
        public AppEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                App.Current.Resources.TryGetValue("BrandColor", out object colorObj);

                this.EditText.FocusChange += OnFoucesChanged;
            }
        }

        private void OnFoucesChanged(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                App.Current.Resources.TryGetValue("BrandColor", out object colorObj);

                if (colorObj != null && colorObj is Xamarin.Forms.Color formsColor)
                {
                    var color = formsColor.ToAndroid();

                    Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcIn);
                }
            }
            else
            {
                App.Current.Resources.TryGetValue("TextColor", out object colorObj);

                if (colorObj != null && colorObj is Xamarin.Forms.Color formsColor)
                {
                    var color = formsColor.ToAndroid();

                    Control.Background.SetColorFilter(color, PorterDuff.Mode.SrcIn);
                }
            }
        }
    }
}