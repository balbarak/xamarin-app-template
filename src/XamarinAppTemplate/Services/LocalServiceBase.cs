using System;
using System.Collections.Generic;
using System.Text;
using XamarinAppTemplate.Persistance.Repositories;

namespace XamarinAppTemplate.Services
{
    public class LocalServiceBase
    {
        protected GenericRepository _repository;

        protected string[] Includes { get; set; }

        public LocalServiceBase()
        {
            this._repository = new GenericRepository();
        }
    }
}
