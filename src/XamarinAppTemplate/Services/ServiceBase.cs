using System;
using System.Collections.Generic;
using System.Text;
using XamarinAppTemplate.Persistance.Repositories;

namespace XamarinAppTemplate.Services
{
    public class ServiceBase
    {
        protected GenericRepository _repository;

        protected string[] Includes { get; set; }

        public ServiceBase()
        {
            this._repository = new GenericRepository();
        }
    }
}
