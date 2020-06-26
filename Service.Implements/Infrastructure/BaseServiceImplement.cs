using Data.Infrastructure;
using Domain.Implements.Infrastructure;
using Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace Service.Implements.Infrastructure
{
    public abstract class BaseServiceImplement<T> : IBaseService<T> where T : class
    {
        private BaseRepository<T> LocalRepository { get; }
        protected BaseServiceImplement(BaseRepository<T> repository)
        {
            LocalRepository=repository;
        }
        public void Delete(Expression<Func<T, bool>> predicate)
        {
            LocalRepository.Delete(predicate);
        }

        public T Get(object key)
        {
            return LocalRepository.Get(key);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return LocalRepository.Get(predicate);
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            return LocalRepository.Search(predicate);
        }

        public PageModel<T> SearchPage(PageCondition<T> condition)
        {
            return LocalRepository.Search(condition);
        }

        public void Update(T entity)
        {
            LocalRepository.Update(entity);
        }
    }
}
