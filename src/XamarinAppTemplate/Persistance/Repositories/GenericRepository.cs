using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using XamarinAppTemplate.Models;

namespace XamarinAppTemplate.Persistance.Repositories
{
    public class GenericRepository
    {
        internal XamarinAppTemplateDbContext _context;

        public GenericRepository() { }

        public GenericRepository(XamarinAppTemplateDbContext context)
        {
            this._context = context;

        }

        public virtual TEntity Create<TEntity>(TEntity entity) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();


            dbSet.Add(entity);

            if (_context == null)
            {
                context.SaveChanges();
                context.Dispose();
            }

            return entity;
        }

        public virtual TEntity Update<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            context.Update(entityToUpdate);

            if (_context == null)
            {
                context.SaveChanges();
                context.Dispose();
            }

            return entityToUpdate;
        }

        public virtual void Delete<TEntity>(string id) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            var found = dbSet.Find(id);

            dbSet.Remove(found);

            if (_context == null)
            {
                context.SaveChanges();
                context.Dispose();
            }
        }

        public virtual void Delete<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            dbSet.Remove(entityToDelete);

            if (_context == null)
            {
                context.SaveChanges();
                context.Dispose();
            }
        }

        public virtual int Count<TEntity>() where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            int count;

            count = dbSet.Count();

            if (_context == null)
                context.Dispose();

            return count;
        }

        public virtual int Count<TEntity>(SearchCriteriaSqlite<TEntity> search) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            IQueryable<TEntity> query = dbSet;

            int count = 0;

            if (search.FilterExpression != null)
            {
                query = query.Where(search.FilterExpression);
            }

            count = query.Count();

            if (_context == null)
                context.Dispose();

            return count;
        }

        public virtual int Count<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            IQueryable<TEntity> query = dbSet;

            int count = 0;

            query = query.Where(filter);

            count = query.Count();

            if (_context == null)
                context.Dispose();

            return count;
        }

        public virtual SearchResultSqlite<TEntity> Search<TEntity>(SearchCriteriaSqlite<TEntity> SearchCriteriaSqlite, params string[] includes) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            IQueryable<TEntity> query = dbSet;

            if (SearchCriteriaSqlite.FilterExpression != null)
            {
                query = query.Where(SearchCriteriaSqlite.FilterExpression);
            }

            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }

            if (SearchCriteriaSqlite.SortExpression != null)
            {
                query = SearchCriteriaSqlite.SortExpression(query);
            }

            SearchResultSqlite<TEntity> result = new SearchResultSqlite<TEntity>(SearchCriteriaSqlite)
            {
                TotalResultsCount = query.Count(),
            };

            query = query.Skip(SearchCriteriaSqlite.StartIndex).Take(SearchCriteriaSqlite.PageSize);

            result.Result = query.ToList();


            if (_context == null)
                context.Dispose();

            return result;

        }

        public virtual IEnumerable<TEntity> Get<TEntity>(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string[] includeProperties = null, int? maxSize = null) where TEntity : class
        {
            XamarinAppTemplateDbContext context = _context ?? new XamarinAppTemplateDbContext();

            var dbSet = context.Set<TEntity>();

            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (maxSize.HasValue)
                query = query.Take(maxSize.Value);


            var result = query.ToList();

            if (_context == null)
                context.Dispose();

            return result;
        }
    }
}
