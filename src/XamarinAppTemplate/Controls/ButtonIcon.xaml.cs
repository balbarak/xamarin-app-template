using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonIcon : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
          nameof(Text),
          typeof(string),
          typeof(ButtonIcon),
          null);

        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
          nameof(TextColor),
          typeof(Color),
          typeof(ButtonIcon),
          null);

        public Color TextColor { get { return (Color)GetValue(TextColorProperty); } set { SetValue(TextColorProperty, value); } }

        public static readonly BindableProperty IconProperty = BindableProperty.Create(
          nameof(Icon),
          typeof(string),
          typeof(ButtonIcon),
          null);

        public string Icon { get { return (string)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
        nameof(IconColor),
        typeof(Color),
        typeof(ButtonIcon),
        Color.Black);

        public Color IconColor { get { return (Color)GetValue(IconColorProperty); } set { SetValue(IconColorProperty, value); } }


        public static readonly BindableProperty TouchColorProperty = BindableProperty.Create(
        nameof(TouchColor),
        typeof(Color),
        typeof(ButtonIcon),
        null);

        public Color TouchColor { get { return (Color)GetValue(TouchColorProperty); } set { SetValue(TouchColorProperty, value); } }


        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
       nameof(Command),
       typeof(ICommand),
       typeof(ButtonIcon),
       null);

        public ICommand Command { get { return (ICommand)GetValue(CommandProperty); } set { SetValue(CommandProperty, value); } }


        public ButtonIcon()
        {
            InitializeComponent();
        }
    }
}