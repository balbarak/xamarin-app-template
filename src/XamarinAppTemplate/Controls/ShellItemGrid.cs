using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate
{
    public class ShellItemGrid : Grid
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected), 
            typeof(bool), 
            typeof(ShellItemGrid), 
            false);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
    }
}
