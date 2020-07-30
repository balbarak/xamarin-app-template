using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using XamarinAppTemplate;
using XamarinAppTemplate.Droid.Renders;

[assembly: ExportRenderer(typeof(BorderedEntry), typeof(BorderedEntryRenderer))]

namespace XamarinAppTemplate.Droid.Renders
{
    public class BorderedEntryRenderer : EntryRenderer
    {
        public BorderedEntry BorderEntryElement => Element as BorderedEntry;

        public BorderedEntryRenderer(Context context) : base(context)
        {

        }

        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            UpdateBackground(control);
            return control;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == BorderedEntry.CornerRadiusProperty.PropertyName)
            {
                UpdateBackground();
            }
            else if (e.PropertyName == BorderedEntry.BorderThicknessProperty.PropertyName)
            {
                UpdateBackground();
            }
            else if (e.PropertyName == BorderedEntry.BorderColorProperty.PropertyName)
            {
                UpdateBackground();
            }
            else if (e.PropertyName == "IsFocused")
            {
                //if (BorderEntryElement.IsFocued)
                //{
                //    UpdateBackground();
                //    BorderEntryElement.IsFocued = false;
                //}
                //else
                //{
                //    BorderEntryElement.IsFocued = true;
                //    UpdateFocusColor(Control);
                //}

            }

            base.OnElementPropertyChanged(sender, e);
        }

        protected override void UpdateBackgroundColor()
        {
            UpdateBackground();
        }
        protected void UpdateBackground(FormsEditText control)
        {
            if (control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(BorderEntryElement.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(BorderEntryElement.BorderThickness), BorderEntryElement.BorderColor.ToAndroid());
            control.SetBackground(gd);

            var padTop = (int)Context.ToPixels(BorderEntryElement.Padding.Top);
            var padBottom = (int)Context.ToPixels(BorderEntryElement.Padding.Bottom);
            var padLeft = (int)Context.ToPixels(BorderEntryElement.Padding.Left);
            var padRight = (int)Context.ToPixels(BorderEntryElement.Padding.Right);

            control.SetPadding(padLeft, padTop, padRight, padBottom);
        }

        protected void UpdateFocusColor(FormsEditText control)
        {
            if (control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(BorderEntryElement.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(BorderEntryElement.BorderThickness), BorderEntryElement.FocusColor.ToAndroid());
            control.SetBackground(gd);

            var padTop = (int)Context.ToPixels(BorderEntryElement.Padding.Top);
            var padBottom = (int)Context.ToPixels(BorderEntryElement.Padding.Bottom);
            var padLeft = (int)Context.ToPixels(BorderEntryElement.Padding.Left);
            var padRight = (int)Context.ToPixels(BorderEntryElement.Padding.Right);

            control.SetPadding(padLeft, padTop, padRight, padBottom);
        }

        protected void UpdateBackground()
        {
            UpdateBackground(Control);
        }
    }
}