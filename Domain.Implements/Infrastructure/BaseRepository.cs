using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Infrastructure;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Domain.Implements.Infrastructure
{
    public abstract class BaseRepository<T> : ISearchRepository<T>,IModifyRepository<T> where T : class
    {
        public DbSet<T> Set { get => Context.Set<T>(); }
        public DbContext Context { get; }
        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public T Insert(T entity)
        {
            return Set.Add(entity).Entity;
        }

        public void Insert(params T[] entities)
        {
            Set.AddRange(entities);
        }

        public void Insert(IEnumerable<T> entities)
        {
            Set.AddRange(entities);
        }

        public void Update(T entity)
        {
            Set.Update(entity);
        }

        public void Update(params T[] entities)
        {
            Set.UpdateRange(entities);
        }

        public void Update(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updator)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(params T[] entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void DeleteByKey(object key)
        {
            throw new NotImplementedException();
        }

        public void DeleteByKeys(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public T Get(object key)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> Search()
        {
            throw new NotImplementedException();
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order)
        {
            throw new NotImplementedException();
        }

        public List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order, bool isDesc)
        {
            throw new NotImplementedException();
        }

        public PageModel<T> Search(PageCondition<T> condition)
        {
            throw new NotImplementedException();
        }
    }
}
