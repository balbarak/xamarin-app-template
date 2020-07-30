using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class ClickableStackLayout : StackLayout
    {
        private readonly TapGestureRecognizer _tapGesture;

        public event EventHandler OnClicked;

        public ClickableStackLayout()
        {
            _tapGesture = new TapGestureRecognizer();

            _tapGesture.Tapped += OnTapped;

            GestureRecognizers.Add(_tapGesture);
        }

        private void OnTapped(object sender, EventArgs e)
        {
            OnClicked?.Invoke(sender, e);
        }
    }
}
