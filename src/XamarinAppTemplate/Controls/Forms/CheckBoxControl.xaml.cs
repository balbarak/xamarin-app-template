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
    public partial class CheckBoxControl : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(string),
        typeof(CheckBoxControl),
        null);

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
        nameof(IsChecked),
        typeof(bool),
        typeof(CheckBoxControl),
        false);

        public static readonly BindableProperty CheckedTextProperty = BindableProperty.Create(
        nameof(CheckedText),
        typeof(string),
        typeof(CheckBoxControl),
        defaultValueCreator: binding=> ((CheckBoxControl) binding).Text);

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(Color),
        typeof(Color),
        typeof(CheckBoxControl),
        null);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(CheckBoxControl),
        null);

        public static readonly BindableProperty CheckedTextColorProperty = BindableProperty.Create(
        nameof(CheckedTextColor),
        typeof(Color),
        typeof(CheckBoxControl),
        defaultValueCreator: binding => ((CheckBoxControl)binding).TextColor);


        public static readonly BindableProperty CheckedColorProperty = BindableProperty.Create(
        nameof(CheckedColor),
        typeof(Color),
        typeof(CheckBoxControl),
        defaultValueCreator: binding => ((CheckBoxControl)binding).Color);

        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }
        public string CheckedText { get { return (string)GetValue(CheckedTextProperty); } set { SetValue(CheckedTextProperty, value); } }
        public Color Color { get { return (Color)GetValue(ColorProperty); } set { SetValue(ColorProperty, value); } }
        public Color TextColor { get { return (Color)GetValue(TextColorProperty); } set { SetValue(TextColorProperty, value); } }
        public Color CheckedColor { get { return (Color)GetValue(CheckedColorProperty); } set { SetValue(CheckedColorProperty, value); } }
        public Color CheckedTextColor { get { return (Color)GetValue(CheckedTextColorProperty); } set { SetValue(CheckedTextColorProperty, value); } }
        public bool IsChecked { get { return (bool)GetValue(IsCheckedProperty); } set { SetValue(IsCheckedProperty, value); } }


        public CheckBoxControl()
        {
            InitializeComponent();
        }

        private void OnTapped(object sender, EventArgs e)
        {
            checkBox.IsChecked = !checkBox.IsChecked;
        }
    }
}