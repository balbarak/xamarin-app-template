using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class TapBehavior : Behavior<Frame>
    {
        public static readonly BindableProperty TappedColorProperty = BindableProperty.Create(
           nameof(TappedColorProperty),
           typeof(Color),
           typeof(TapBehavior),
           Color.Red);

        private Color _originalColor;

        public Color TappedColor
        {
            get { return (Color)GetValue(TappedColorProperty); }
            set { SetValue(TappedColorProperty, value); }
        }

        public TapBehavior()
        {

        }

        
        public TapBehavior(Color tappedColor)
        {
            TappedColor = tappedColor;
        }

        protected override void OnAttachedTo(Frame bindable)
        {
            _originalColor = bindable.BackgroundColor;

            var tapGesture = GetTapGesture(bindable);

            if (tapGesture != null)
                tapGesture.Tapped += OnTapped;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Frame bindable)
        {

            var tapGesture = GetTapGesture(bindable);

            if (tapGesture != null)
                tapGesture.Tapped -= OnTapped;

            base.OnDetachingFrom(bindable);
        }

        private TapGestureRecognizer GetTapGesture(Frame frame)
        {
            foreach (var item in frame.GestureRecognizers)
            {
                if (item is TapGestureRecognizer gesture)
                    return gesture;
            }

            return null;
        }

        private async void OnTapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;

            if (frame == null)
                return;

            frame.BackgroundColor = TappedColor;

            await Task.Delay(100);

            frame.BackgroundColor = _originalColor;
        }

    }
}
