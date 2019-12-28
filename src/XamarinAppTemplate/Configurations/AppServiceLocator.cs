using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace XamarinAppTemplate
{
    public class AppServiceLocator : IDisposable
    {
        static private readonly ConcurrentDictionary<int, AppServiceLocator> _serviceLocators = new ConcurrentDictionary<int, AppServiceLocator>();

        static private ServiceProvider _rootServiceProvider = null;

        private IServiceScope _serviceScope = null;

        static public AppServiceLocator Current
        {
            get
            {
                return _serviceLocators.GetOrAdd(1, new AppServiceLocator());
            }
        }

        public AppServiceLocator()
        {
            _serviceScope = _rootServiceProvider.CreateScope();
        }

        static public void Configure(IServiceCollection serviceCollections)
        {
            _rootServiceProvider = serviceCollections.BuildServiceProvider();

        }

        public T GetService<T>(bool isRequired = true)
        {
            if (isRequired)
            {
                return _serviceScope.ServiceProvider.GetRequiredService<T>();
            }

            return _serviceScope.ServiceProvider.GetService<T>();
        }

        public object GetService(Type type)
        {
            return _serviceScope.ServiceProvider.GetService(type);
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_serviceScope != null)
                {
                    _serviceScope.Dispose();
                }
            }
        }
        #endregion
    }
}
