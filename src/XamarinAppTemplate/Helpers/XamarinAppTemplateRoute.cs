using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace XamarinAppTemplate.Helpers
{
    public class XamarinAppTemplateRoute : RouteFactory
    {
        private static Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();
        private readonly Type _pageType;

        public XamarinAppTemplateRoute(Type viewModelType, Type pageType)
        {
            _pageType = pageType;
            _mappings.Add(viewModelType, pageType);
        }

        public override Element GetOrCreate()
        {
            return (Element)Activator.CreateInstance(_pageType);
        }

        public static Type GetPageByViewModel(Type viewModel)
        {
            if (!_mappings.ContainsKey(viewModel))
            {
                throw new KeyNotFoundException($"No map for ${viewModel} was found on navigation mappings");
            }

            return _mappings[viewModel];
        }

        public static Type GetViewModelByPage(Type page)
        {
            if (!_mappings.ContainsValue(page))
            {
                throw new KeyNotFoundException($"No map for ${page} was found on navigation mappings");
            }

            return _mappings.FirstOrDefault(x => x.Value == page).Key;

        }

        public static void Register(Type viewModel, Type page)
        {
            Routing.RegisterRoute(viewModel.Name,
                new XamarinAppTemplateRoute(viewModel, page));
        }

        public override bool Equals(object obj)
        {
            if ((obj is XamarinAppTemplateRoute typeRouteFactory))
                return typeRouteFactory._pageType == _pageType;

            return false;
        }

        public override int GetHashCode()
        {
            return _pageType.GetHashCode();
        }
    }
}
