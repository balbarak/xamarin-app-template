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
    public partial class Loading : ContentView
    {
        public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
            nameof(IsBusy),
            typeof(bool),
            typeof(Loading),
            false);

        public bool IsBusy { get => (bool)GetValue(IsBusyProperty); set => SetValue(IsBusyProperty, value); }

        public Loading()
        {
            InitializeComponent();
        }
    }
}