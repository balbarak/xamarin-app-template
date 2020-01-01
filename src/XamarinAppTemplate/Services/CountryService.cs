using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAppTemplate.Models;

namespace XamarinAppTemplate.Services
{
    public class CountryService : ServiceBase
    {
        public Task<Country[]> GetAll()
        {
            return Task.Run(() =>
            {
                return _repository.Get<Country>().ToArray();

            });
        }
    }
}
