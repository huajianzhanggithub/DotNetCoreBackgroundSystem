using Data.Infrastructure;
using Domain.Infrastructure;
using Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace Service.Implements.Infrastructure
{
    public abstract class BaseServiceImplement<T> : IBaseService<T>
    {
        private IRepository<T> LocalRepository { get; }
        protected BaseServiceImplement(IRepository<T> repository)
        {
            LocalRepository=repository;
        }
        public void Delete(Expression<Func<T, bool>> predicate)
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

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public PageModel<T> SearchPage(PageCondition<T> condition)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
