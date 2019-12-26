using System;
using System.Collections.Generic;
using System.Text;
using XamarinAppTemplate.ViewModels;
using XamarinAppTemplate.Views;

namespace XamarinAppTemplate.Services
{
    public class NavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            MapViewModels();
        }


        private void MapViewModels()
        {
            _mappings.Add(typeof(HomeViewModel), typeof(HomePage));
        }
    }
}
