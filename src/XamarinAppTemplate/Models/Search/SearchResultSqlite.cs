using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppTemplate.Models
{
    public class SearchResultSqlite<T> where T : class
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public SearchCriteriaSqlite<T> SearchCriteria { get; set; }

        public List<T> Result { get; set; }

        public int TotalResultsCount { get; set; }

        public int PageCount
        {
            get { return (int)Math.Ceiling((double)TotalResultsCount / PageSize); }
        }

        public SearchResultSqlite()
        {
            this.Result = new List<T>();
        }

        public SearchResultSqlite(SearchCriteriaSqlite<T> searchCriteria) : this()
        {
            this.PageNumber = searchCriteria.PageNumber;
            this.PageSize = searchCriteria.PageSize;
            this.SearchCriteria = searchCriteria;
        }
    }
}
