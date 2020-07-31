using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchControl : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(SwitchControl),
            null);

        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(
            nameof(IsToggled),
            typeof(bool),
            typeof(SwitchControl),
            false);
        public bool IsToggled { get { return (bool)GetValue(IsToggledProperty); } set { SetValue(IsToggledProperty, value); } }


        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(SwitchControl),
            null);
        public Color TextColor { get { return (Color)GetValue(TextColorProperty); } set { SetValue(TextColorProperty, value); } }

        public static readonly BindableProperty ToggledTextProperty = BindableProperty.Create(
            nameof(ToggledText),
            typeof(string),
            typeof(SwitchControl),
            defaultValueCreator: binding => ((SwitchControl)binding).Text);
        public string ToggledText { get { return (string)GetValue(ToggledTextProperty); } set { SetValue(ToggledTextProperty, value); } }

        public static readonly BindableProperty ToggledTextColorProperty = BindableProperty.Create(
            nameof(ToggledTextColor),
            typeof(Color),
            typeof(SwitchControl),
            defaultValueCreator: binding => ((SwitchControl)binding).TextColor);
        public Color ToggledTextColor { get { return (Color)GetValue(ToggledTextColorProperty); } set { SetValue(ToggledTextColorProperty, value); } }

        public SwitchControl()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, EventArgs e)
        {
            switchControl.IsToggled = !switchControl.IsToggled;
        }
    }
}