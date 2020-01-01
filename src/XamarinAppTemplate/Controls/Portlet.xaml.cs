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
    public partial class Portlet : ContentView
    {

        public static readonly BindableProperty HasFooterProperty = BindableProperty.Create(
            nameof(HasFooter),
            typeof(bool),
            typeof(Portlet),
            false);

        public static readonly BindableProperty HasHeaderProperty = BindableProperty.Create(
            nameof(HasHeader),
            typeof(bool),
            typeof(Portlet),
            false);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
           nameof(Title),
           typeof(string),
           typeof(Portlet),
           null);

        public static readonly BindableProperty BodyProperty = BindableProperty.Create(
            nameof(Body),
            typeof(View),
            typeof(Portlet),
            null);

        public static readonly BindableProperty HeaderProperty = BindableProperty.Create(
            nameof(Header),
            typeof(View),
            typeof(Portlet),
            null,
            propertyChanged: OnHeaderChanged);

        public static readonly BindableProperty FooterProperty = BindableProperty.Create(
          nameof(Footer),
          typeof(View),
          typeof(Portlet),
          null,
          propertyChanged: OnFooterChanged);

        public View Body
        {
            get => (View)GetValue(BodyProperty);
            set => SetValue(BodyProperty, value);
        }

        public View Header
        {
            get => (View)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public View Footer
        {
            get => (View)GetValue(FooterProperty);
            set => SetValue(FooterProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public bool HasFooter
        {
            get => (bool)GetValue(HasFooterProperty);
            set => SetValue(HasFooterProperty, value);
        }

        public bool HasHeader
        {
            get => (bool)GetValue(HasHeaderProperty);
            set => SetValue(HasHeaderProperty, value);
        }


        public Portlet()
        {

            InitializeComponent();
        }

        

        static void OnFooterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var portlet = bindable as Portlet;

            if (portlet == null)
                return;

            if (newValue != null)
            {
                portlet.HasFooter = true;
            }
            else
            {
                portlet.HasFooter = false;
            }
        }

        static void OnHeaderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var portlet = bindable as Portlet;

            if (portlet == null)
                return;

            if (newValue != null)
            {
                portlet.HasHeader = true;
            }
            else
            {
                portlet.HasHeader = false;
            }
        }

    }
}