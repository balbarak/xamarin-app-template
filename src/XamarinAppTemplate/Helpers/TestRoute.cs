using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinAppTemplate.Views;

namespace XamarinAppTemplate.Helpers
{
    public class TestRoute : RouteFactory
    {
        public TestRoute()
        {
        }

        public override Element GetOrCreate()
        {
            var page = new LoginPage();
            
            return page;
        }
    }
}
