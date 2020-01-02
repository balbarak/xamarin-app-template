using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinAppTemplate.Controls
{
    public class ButtonFrame : Frame
    {
        public static readonly BindableProperty TappedColorProperty = BindableProperty.Create(
           nameof(TappedColorProperty),
           typeof(Color),
           typeof(ButtonFrame),
           Color.Red);

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ButtonFrame),
            null);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Color TappedColor
        {
            get { return (Color)GetValue(TappedColorProperty); }
            set { SetValue(TappedColorProperty, value); }
        }

        public ButtonFrame()
        {
            CornerRadius = 10;
            Padding = 15;
            BorderColor = Color.Transparent;

        }

        protected override void OnParentSet()
        {
            SetTapCommand();
            SetTapBehavior();
        }

        private void SetTapCommand()
        {
            var tapGesture = new TapGestureRecognizer();

            tapGesture.Tapped += (sender, args) =>
             {
                 if (Command != null && Command.CanExecute(null))
                 {
                     Command.Execute(null);
                 }
             };

            GestureRecognizers.Add(tapGesture);
        }

        private void SetTapBehavior()
        {
            TapBehavior behavior = new TapBehavior(TappedColor);
            

            Behaviors.Add(behavior);
        }
    }
}
