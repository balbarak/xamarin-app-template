using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppTemplate.Validations;

namespace XamarinAppTemplate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormGroupEntry : ContentView
    {
        public static readonly BindableProperty LabelProperty = BindableProperty.Create(
        nameof(Label),
        typeof(string),
        typeof(FormGroupEntry),
        null);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text),
        typeof(ValidatableEntry),
        typeof(FormGroupEntry),
        new ValidatableEntry());

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
       nameof(IsPassword),
       typeof(bool),
       typeof(FormGroupEntry),
       false);

        public string Label { get { return (string)GetValue(LabelProperty); } set { SetValue(LabelProperty, value); } }

        public ValidatableEntry Text { get { return (ValidatableEntry)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        public bool IsPassword { get { return (bool)GetValue(IsPasswordProperty); } set { SetValue(IsPasswordProperty, value); } }

        public FormGroupEntry()
        {
            InitializeComponent();
        }
    }
}