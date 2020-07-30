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
        public SwitchControl()
        {
            InitializeComponent();
        }
    }
}