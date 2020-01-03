using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinAppTemplate.Controls;
using XamarinAppTemplate.Droid.Renders;

[assembly: ExportRenderer(typeof(FormGroupEntry), typeof(FormGroupEntryRenderer))]
namespace XamarinAppTemplate.Droid.Renders
{
    public class FormGroupEntryRenderer : EntryRenderer
    {
        public FormGroupEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

            }
        }
    }
}