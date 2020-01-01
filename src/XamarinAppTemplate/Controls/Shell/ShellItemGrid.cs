using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinAppTemplate.ViewModels;

namespace XamarinAppTemplate
{
    public class ShellItemGrid : Grid
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected), 
            typeof(bool), 
            typeof(ShellItemGrid), 
            false);

        public static readonly BindableProperty ParentContextProperty = BindableProperty.Create(
            nameof(ParentContext), 
            typeof(AppShellViewModel), 
            typeof(ShellItemGrid), 
            null);

        public AppShellViewModel ParentContext
        {
            get { return (AppShellViewModel)GetValue(ParentContextProperty); }
            set { SetValue(ParentContextProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

    }
}
