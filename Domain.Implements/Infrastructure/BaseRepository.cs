using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Data.Infrastructure;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

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
            Set.Where(predicate).UpdateFromQuery(updator);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void Delete(params T[] entities)
        {
            Set.RemoveRange(entities);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Set.Where(predicate).DeleteFromQuery();
        }

        public void DeleteByKey(object key)
        {
            Delete(Set.Find(key));
        }

        public void DeleteByKeys(params object[] keys)
        {
            foreach (var key in keys)
            {
                DeleteByKey(key);
            }
        }

        public T Get(object key)
        {
            return Set.Find(key);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate); // SingleOrDefault待定
        }

        public int Count()
        {
            return Set.Count();
        }

        public long LongCount()
        {
            return Set.LongCount();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Set.Count(predicate);
        }

        public long LongCount(Expression<Func<T, bool>> predicate)
        {
            return Set.LongCount(predicate);
        }

        public bool IsExists(Expression<Func<T, bool>> predicate)
        {
            return Set.Any(predicate);
        }

        public List<T> Search()
        {
            return Set.ToList();
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate).ToList();
        }

        public IEnumerable<T> Query()
        {
            return Set;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order)
        {
            return Search(predicate, order, false);
        }

        public List<T> Search<P>(Expression<Func<T, bool>> predicate, Expression<Func<T, P>> order, bool isDesc)
        {
            var result = Set.Where(predicate);
            if (isDesc)
            {
                result = result.OrderByDescending(order);
            }
            else
            {
                result =  result.OrderBy(order);
            }
            return result.ToList();
        }

        public PageModel<T> Search(PageCondition<T> condition)
        {
            throw new NotImplementedException();
        }
    }
}
